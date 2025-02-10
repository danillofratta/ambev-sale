using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.WebApi.Controllers.Sale.Cancel;
using FluentValidation;

namespace Ambev.Sale.Core.Application.Sales.Cancel
{
    public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
    {
        private readonly ISaleRepository _repository;
        public CancelSaleRequestValidator(ISaleRepository repository)
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
}
