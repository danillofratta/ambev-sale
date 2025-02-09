using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.Sale.Core.Application.Sales.Delete;
using Ambev.Sale.Core.Domain.Enum;
using Ambev.Sale.Core.Domain.Repository;
using FluentValidation;
using FluentValidation.Validators;


namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
    {
        private readonly ISaleRepository _repository;
        public DeleteSaleCommandValidator(ISaleRepository repository)
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
