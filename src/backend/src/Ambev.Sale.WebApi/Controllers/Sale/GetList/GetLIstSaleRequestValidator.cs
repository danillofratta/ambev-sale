using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using FluentValidation;

namespace Ambev.Sale.WebApi.Controllers.Sale.GetList;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class GetLIstSaleRequestValidator : AbstractValidator<GetListSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetLIstSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
