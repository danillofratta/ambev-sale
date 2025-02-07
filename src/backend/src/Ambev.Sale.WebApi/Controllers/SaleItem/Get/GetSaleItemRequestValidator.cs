using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using FluentValidation;

namespace Ambev.Sale.WebApi.Controllers.SaleItem.Get;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class GetSaleItemRequestValidator : AbstractValidator<GetSaleItemRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetSaleItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Item ID is required");
    }
}
