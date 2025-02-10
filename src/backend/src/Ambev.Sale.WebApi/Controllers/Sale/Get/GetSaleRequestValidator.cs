using FluentValidation;

namespace Ambev.Sale.WebApi.Controllers.Sale.Get;

public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{

    public GetSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
