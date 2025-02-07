using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ambev.Sale.Core.Domain.Repository;
using AutoMapper;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResult>
    {
        private readonly SaleItemRepository _repository;
        private readonly IMapper _mapper;

        public CancelSaleItemHandler(SaleItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CancelSaleItemResult> Handle(CancelSaleItemCommand command, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleItemCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(command, cancellationToken);            
            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);
            
            var record = await _repository.GetByIdAsync(command.id);            
            record.Status = Infrastructure.ORN.Enum.SaleItemStatus.Cancelled;
            var update = await _repository.UpdateAsync(record);
            
            return _mapper.Map<CancelSaleItemResult>(update); ;            
        }
    }
}
