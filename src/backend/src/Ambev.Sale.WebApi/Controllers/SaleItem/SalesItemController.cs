using Ambev.Sale.Core.Application.SaleItem.Cancel;
using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Application.Sales.Get;
using Ambev.Sale.Core.Application.Sales.Modify;
using Ambev.Sale.Core.Application.SalesItem.Get;
using Ambev.Sale.WebApi.Common;
using Ambev.Sale.WebApi.Controllers.Sale.Create;
using Ambev.Sale.WebApi.Controllers.Sale.Get;
using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using Ambev.Sale.WebApi.Controllers.SaleItem.Cancel;
using Ambev.Sale.WebApi.Controllers.SaleItem.Get;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.Sale.WebApi.Controllers.SaleItem;

[ApiController]
[Route("api/v1/[controller]")]
public class SalesItemController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SalesItemController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPut("Cancel")]
    [ProducesResponseType(typeof(ApiResponseWithData<CancelSaleItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelItemSale([FromBody] CancelSaleItemRequest request, CancellationToken cancellationToken)
    {
        //var validator = new CreateUserRequestValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //return BadRequest(validationResult.Errors);

        //todo call validador from command

        var command = _mapper.Map<CancelSaleItemCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CancelSaleItemResponse>
        {
            Success = true,
            Message = "Item cancelled successfully",
            Data = _mapper.Map<CancelSaleItemResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItemSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleItemRequest { Id = id };
        var validator = new GetSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleItemQuery>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleItemResponse>
        {
            Success = true,
            Message = "Item retrieved successfully",
            Data = _mapper.Map<GetSaleItemResponse>(response)
        });
    }
}

