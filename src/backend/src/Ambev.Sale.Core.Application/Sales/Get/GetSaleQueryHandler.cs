using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ambev.Sale.Core.Domain.Repository;
using AutoMapper;

namespace Ambev.Sale.Core.Application.Sales.Get;
   
public class GetSaleQueryHandler : IRequestHandler<GetSaleQuery, GetSaleQueryResult>
{
    private readonly SaleRepository _repository;
    private readonly IMapper _mapper;

    public GetSaleQueryHandler(SaleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
        
    public async Task<GetSaleQueryResult> Handle(GetSaleQuery command, CancellationToken cancellationToken)
    {
        var validator = new GetSaleQueryValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (validationResult != null && !validationResult.IsValid)                
            throw new ValidationException(validationResult.Errors);
            
        var sale = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (sale == null) 
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");
                        
        return _mapper.Map<GetSaleQueryResult>(sale);         
    }
}

