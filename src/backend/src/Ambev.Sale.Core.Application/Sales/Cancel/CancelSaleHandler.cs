using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using Ambev.Sale.Core.Domain.Repository;

namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public CancelSaleHandler(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CancelSaleResult> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(command, cancellationToken);            
            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);

            var record = await _repository.GetByIdAsync(command.id);
            record.Status = Ambev.Sale.Core.Domain.Enum.SaleStatus.Cancelled;
            
            var update = await _repository.UpdateAsync(record);
            
            return _mapper.Map<CancelSaleResult>(update); ;            
        }
    }
}
