﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Domain.Enum;
using Ambev.Sale.Core.Domain.Repository;
using FluentValidation;
using FluentValidation.Validators;


namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class CancelSaleCommandValidator : AbstractValidator<CancelSaleCommand>
    {
        private readonly ISaleRepository _repository;
        public CancelSaleCommandValidator(ISaleRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.id)
                .NotEmpty().WithMessage("Sale is required")
                .MustAsync(ExistInDatabase).WithMessage("Sale not found")
                .MustAsync(SaleAlreadyCancelled).WithMessage("Sale already cancelled");
        }
        private async Task<bool> ExistInDatabase(Guid id, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record != null) { return true; } else { return false; }
        }

        private async Task<bool> SaleAlreadyCancelled(Guid id, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record != null) 
            {
                if (record.Status == SaleStatus.Cancelled)
                return false; 
            }

            return true;
            
        }
    }
}
