using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.WebApi.Controllers.Sale.Create;
using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using FluentValidation;

namespace Ambev.Sale.WebApi.Controllers.Sale.Delete;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    private readonly ISaleRepository _repository;
    public DeleteSaleRequestValidator(ISaleRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Sale is required")
            .MustAsync(ExistInDatabase).WithMessage("Sale not found");
    }
    private async Task<bool> ExistInDatabase(Guid id, CancellationToken cancellationToken)
    {
        var record = await _repository.GetByIdAsync(id);
        if (record != null) { return true; } else { return false; }
    }
}
