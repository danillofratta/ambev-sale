using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Application.Sales.Get;
using Ambev.Sale.Core.Application.Sales.GetList;
using Ambev.Sale.Core.Application.Sales.Modify;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.WebApi.Common;
using Ambev.Sale.WebApi.Controllers.Sale.Cancel;
using Ambev.Sale.WebApi.Controllers.Sale.Create;
using Ambev.Sale.WebApi.Controllers.Sale.Get;
using Ambev.Sale.WebApi.Controllers.Sale.GetList;
using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ambev.Sale.WebApi.Controllers.Sale;

[ApiController]
[Route("api/v1/[controller]")]
public class SalesController : BaseController//ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly SaleRepository _repository;

    public SalesController(IMediator mediator, IMapper mapper, SaleRepository repository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _repository = repository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);        

        var command = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);       

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }


    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<ModifySaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ModifySale([FromBody] ModifySaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new ModifySaleRequestValidator(_repository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var command = _mapper.Map<ModifySaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        //return _mapper.Map<ModifySaleResponse>(response);

        return Created(string.Empty, new ApiResponseWithData<ModifySaleResponse>
        {
            Success = true,
            Message = "User modified successfully",
            Data = _mapper.Map<ModifySaleResponse>(response)
        });
    }

    [HttpPut("Cancel")]
    public async Task<IActionResult> CancelSale([FromBody] CancelSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleRequestValidator(_repository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CancelSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CancelSaleResponse>
        {
            Success = true,
            Message = "Sale cancelled successfully",
            Data = _mapper.Map<CancelSaleResponse>(response)
        });
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRequest { Id = id };
        var validator = new GetSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleQuery>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(response)
        });
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetListSale(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? orderBy = null,
            [FromQuery] bool isDescending = false,
            CancellationToken cancellationToken = default)
    {
        var query = new GetListSaleQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            OrderBy = orderBy,
            IsDescending = isDescending
        };

        //todo map dont work
        var result = await _mediator.Send(query, cancellationToken);
        //var response = _mapper.Map<GetListSaleQueryResult>(result);
        return Ok(result);
        //return Ok(new ApiResponseWithData<GetListSaleResponse>
        //{
        //    Success = true,
        //    Message = "Sale retrieved successfully",
        //    Data = _mapper.Map<GetListSaleResponse>(response)
        //});
    }
}

