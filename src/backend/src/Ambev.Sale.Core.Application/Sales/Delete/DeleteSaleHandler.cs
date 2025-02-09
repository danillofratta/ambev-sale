using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Core.Application.Sales.Delete;
using Ambev.Sale.Core.Application.Sales.Modify;

namespace Ambev.Sale.Core.Application.Sales.Delete
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public DeleteSaleHandler(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeleteSaleResult> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteSaleCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(command, cancellationToken);            
            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);

            var record = await _repository.GetByIdAsync(command.Id);
            record.Status = Ambev.Sale.Core.Domain.Enum.SaleStatus.Cancelled;
            
            var update = await _repository.DeleteAsync(record);
            
            return _mapper.Map<DeleteSaleResult>(update); ;            
        }
    }
}
