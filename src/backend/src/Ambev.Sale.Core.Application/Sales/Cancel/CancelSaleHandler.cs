using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Domain.Entities;

namespace Ambev.Sale.Core.Application.Sales.Cancel
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CancelSaleHandler(IMediator mediator, ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
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

            //publich event 
            await _mediator.Publish(new CreateSaleResult
            {
                Id = update.Id                
            });
            await Task.FromResult("Sale Cancelled");

            return _mapper.Map<CancelSaleResult>(update); ;            
        }
    }
}
