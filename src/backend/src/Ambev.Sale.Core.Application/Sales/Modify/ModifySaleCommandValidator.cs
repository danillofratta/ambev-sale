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
    public class ModifySaleCommandValidator : AbstractValidator<ModifySaleCommand>
    {
        private readonly SaleRepository _repository;

        public ModifySaleCommandValidator(SaleRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.id)
                .NotEmpty().WithMessage("Sale is required")
                .MustAsync(ExistInDatabase).WithMessage("Sale not found");

            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x => x.BranchName).NotEmpty();

            //todo verify => doc coment about alter only sale not itens
            //RuleFor(x => x.SaleItems)
            //    .NotEmpty().WithMessage("The sale must contain at least one item.");

            //RuleForEach(x => x.SaleItems).ChildRules(items =>
            //{
            //    items.RuleFor(i => i.ProductId)
            //        .NotEmpty().WithMessage("Product is required");

            //    items.RuleFor(i => i.Quantity)
            //        .GreaterThan(0).WithMessage("The quantity must be greater than zero.");

            //    items.RuleFor(i => i.UnitPrice)
            //        .GreaterThan(0).WithMessage("Price must be greater than zero.");
            //});
        }

        private async Task<bool> ExistInDatabase(Guid id, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record != null) { return true; } else { return false; }
        }
    }
}
