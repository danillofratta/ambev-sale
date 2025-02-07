using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Domain.Repository;
using FluentValidation;
using FluentValidation.Validators;


namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class CancelSaleCommandValidator : AbstractValidator<CancelSaleCommand>
    {
        private readonly SaleRepository _repository;
        public CancelSaleCommandValidator(SaleRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.id)
                .NotEmpty().WithMessage("Sale is required")
                .MustAsync(ExistInDatabase).WithMessage("Sale not found");
        }
        private async Task<bool> ExistInDatabase(Guid id, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record != null) { return true; } else { return false; }
        }
    }
}
