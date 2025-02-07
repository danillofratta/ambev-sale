using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.WebApi.Controllers.Sale.Cancel;
using FluentValidation;
using FluentValidation.Validators;


namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
    {
        private readonly SaleRepository _repository;
        public CancelSaleRequestValidator(SaleRepository repository)
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
