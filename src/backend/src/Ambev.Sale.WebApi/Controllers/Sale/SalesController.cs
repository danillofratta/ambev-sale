using Ambev.Sale.Common.Validation;
using Ambev.Sale.Core.Application.Sales.Cancel;
using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Application.Sales.Get;
using Ambev.Sale.Core.Application.Sales.GetList;
using Ambev.Sale.Core.Application.Sales.Modify;
using Ambev.Sale.Core.Application.Sales.Delete;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.WebApi.Common;
using Ambev.Sale.WebApi.Controllers.Sale.Cancel;
using Ambev.Sale.WebApi.Controllers.Sale.Create;
using Ambev.Sale.WebApi.Controllers.Sale.Delete;
using Ambev.Sale.WebApi.Controllers.Sale.Get;
using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rebus.Messages;
using System;

namespace Ambev.Sale.WebApi.Controllers.Sale;

[ApiController]
[Route("api/v1/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ISaleRepository _repository;

    public SalesController(IMediator mediator, IMapper mapper, ISaleRepository repository)
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
        try
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
        catch (Exception ex)
        {
            //return BadRequest(ex.Message);

            return BadRequest(new ApiResponseWithData<CreateSaleResponse>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }
    


    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<ModifySaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ModifySale([FromBody] ModifySaleRequest request, CancellationToken cancellationToken)
    {
        try
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
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<ModifySaleResponse>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSale([FromBody] DeleteSaleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new DeleteSaleRequestValidator(_repository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<DeleteSaleResponse>
            {
                Success = true,
                Message = "Sale deleted successfully",
                Data = _mapper.Map<DeleteSaleResponse>(response)
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<DeleteSaleResponse>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }


    [HttpPut("Cancel")]
    public async Task<IActionResult> CancelSale([FromBody] CancelSaleRequest request, CancellationToken cancellationToken)
    {
        try
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
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<CancelSaleResponse>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
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
        catch (Exception ex)
        {
            return NotFound(new ApiResponseWithData<GetSaleResponse>
            {
                Success = false,
                Message = ex.Message
            });
        }
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

        return Ok(result);
    }
}

