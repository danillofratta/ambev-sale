using Ambev.Sale.Core.Domain.Repository;
using FluentValidation;

namespace Ambev.Sale.WebApi.Controllers.Sale.Modify;

public class ModifySaleRequestValidator : AbstractValidator<ModifySaleRequest>
{
    private readonly ISaleRepository _repository;

    public ModifySaleRequestValidator(ISaleRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Item is required")
            .MustAsync(ExistInDatabase).WithMessage("Item not found");

        RuleFor(x => x.CustomerName).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.BranchId).NotEmpty();
        RuleFor(x => x.BranchName).NotEmpty();
    }

    private async Task<bool> ExistInDatabase(Guid id, CancellationToken cancellationToken)
    {
        var record = await _repository.GetByIdAsync(id);
        if (record != null) { return true; } else { return false; }
    }
}

