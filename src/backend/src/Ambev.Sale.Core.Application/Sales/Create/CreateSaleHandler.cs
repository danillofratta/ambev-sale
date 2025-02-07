using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ambev.Sale.Core.Domain.Repository;
using AutoMapper;
using Ambev.Sale.Core.Domain.Service;

namespace Ambev.Sale.Core.Application.Sales.Create
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly SaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly SaleDiscountService _discountService;

        public CreateSaleHandler(SaleDiscountService discountService, SaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _discountService = discountService;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);
            
            var record = _mapper.Map<Ambev.Sale.Infrastructure.ORN.Entities.Sale>(command);
            //todo 
            record.Status = Ambev.Sale.Infrastructure.ORN.Enum.SaleStatus.NotCancelled;            
            record.SaleItems.ForEach(x => x.Status = Ambev.Sale.Infrastructure.ORN.Enum.SaleItemStatus.NotCancelled);

            _discountService.ValidateSaleItems(record.SaleItems);
            if (_discountService.IsValid)
            {
                //todo
                record.TotalAmount = record.SaleItems.Sum(x => x.TotalPrice);

                var created = await _repository.SaveAsync(record);
                var result = _mapper.Map<CreateSaleResult>(created);
                return result;
            }
            return null;            
        }
    }
}
