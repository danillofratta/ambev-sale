using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using FluentValidation;

namespace Ambev.Sale.WebApi.Controllers.Sale.Get;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
