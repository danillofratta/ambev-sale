using FluentValidation;

namespace Ambev.Sale.WebApi.Controllers.Sale.Create;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.BranchId).NotEmpty();
        RuleFor(x => x.BranchName).NotEmpty();

        RuleFor(x => x.SaleItems)
        .NotEmpty().WithMessage("The sale must contain at least one item.");

        RuleForEach(x => x.SaleItems).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("Product is required");

            items.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("The quantity must be greater than zero.");

            items.RuleFor(i => i.UnitPrice)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        });
    }
}
