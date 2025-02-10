﻿using Ambev.Sale.Core.Application.Sales.Cancel;
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
using Ambev.Sale.WebApi.Controllers.Sale.GetList;

namespace Ambev.Sale.WebApi.Controllers.Sale;

/// <summary>
/// Sale EndPoint
/// TODO: create versioning 
/// </summary>
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

    /// <summary>
    /// creates the sale and generates the item discounts and calculates the total sale
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
            return BadRequest(new ApiResponseWithData<CreateSaleResponse>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }


    /// <summary>
    /// Responsible for changing only the sales data
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

            return Created(string.Empty, new ApiResponseWithData<ModifySaleResponse>
            {
                Success = true,
                Message = "Sale modified successfully",
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

    /// <summary>
    /// Responsible for physically deleting the sale
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Responsible for cancel the sale, chance your status
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Responsible to return sale and yours itens
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Responsible to return list of sale 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderBy"></param>
    /// <param name="isDescending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListSale(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? orderBy = null,
            [FromQuery] bool isDescending = false,
            CancellationToken cancellationToken = default)
    {
        try
        {
            if (pageNumber < 1 || pageSize < 1 || pageSize > 100)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid pagination parameters. Page number must be >= 1 and page size must be between 1 and 100."
                });
            }

            var query = new GetListSaleQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                OrderBy = orderBy,
                IsDescending = isDescending
            };

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(new ApiResponseWithData<Core.Application.Sales.GetList.PagedResult<GetListSaleResponse>>
            {
                Success = true,
                Message = "Sales list retrieved successfully",
                Data = new Core.Application.Sales.GetList.PagedResult<GetListSaleResponse>
                {
                    Items = _mapper.Map<List<GetListSaleResponse>>(result.Items),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    TotalPages = result.TotalPages
                }
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                Success = false,
                Message = ex.Message
            });
        }
    }
}

