using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Domain.Repository;
using FluentValidation;
using FluentValidation.Validators;


namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemCommandValidator : AbstractValidator<CancelSaleItemCommand>
    {
        private readonly SaleItemRepository _repository;

        public CancelSaleItemCommandValidator(SaleItemRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.id)
                .NotEmpty().WithMessage("Item is required")
                .MustAsync(ExistInDatabase).WithMessage("Item not found");
        }

        private async Task<bool> ExistInDatabase(Guid id, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record != null) { return true; } else { return false; }
        }
    }
}
