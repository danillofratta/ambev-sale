using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ambev.Sale.Core.Domain.Repository;
using AutoMapper;

namespace Ambev.Sale.Core.Application.SalesItem.Get;

public class GetSaleItemQueryHandler : IRequestHandler<GetSaleItemQuery, GetSaleItemQueryResult>
{
    private readonly SaleItemRepository _repository;
    private readonly IMapper _mapper;

    public GetSaleItemQueryHandler(SaleItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
        
    public async Task<GetSaleItemQueryResult> Handle(GetSaleItemQuery command, CancellationToken cancellationToken)
    {
        var validator = new GetSaleItemQueryValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (validationResult != null && !validationResult.IsValid)                
            throw new ValidationException(validationResult.Errors);
            
        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale == null) 
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");
                        
        return _mapper.Map<GetSaleItemQueryResult>(sale);         
    }
}

