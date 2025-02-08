using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using Ambev.Sale.Core.Domain.Service;
using Ambev.Sale.Core.Domain.Repository;

namespace Ambev.Sale.Core.Application.Sales.Create
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly SaleDiscountService _discountService;
        private readonly IMediator _mediator;

        public CreateSaleHandler(IMediator mediator, SaleDiscountService discountService, ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _discountService = discountService;
            _mediator = mediator;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);
            
            var record = _mapper.Map<Ambev.Sale.Core.Domain.Entities.Sale>(command);
            //todo 
            record.Status = Ambev.Sale.Core.Domain.Enum.SaleStatus.NotCancelled;            
            record.SaleItems.ForEach(x => x.Status = Ambev.Sale.Core.Domain.Enum.SaleItemStatus.NotCancelled);

            _discountService.ValidateSaleItems(record.SaleItems);
            if (_discountService.IsValid)
            {
                //todo verify to put on domain
                record.TotalAmount = record.SaleItems.Sum(x => x.TotalPrice);

                var created = await _repository.SaveAsync(record);
                var result = _mapper.Map<CreateSaleResult>(created);

                await _mediator.Publish(new CreateSaleResult
                {
                    Id = result.Id,
                    Number = result.Number
                });
                await Task.FromResult("Sale Created");

                return result;
            }
            return null;            
        }
    }
}
