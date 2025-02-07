using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;


namespace Ambev.Sale.Core.Application.Sales.Get
{
    public class GetSaleQueryValidator : AbstractValidator<GetSaleQuery>
    {
        public GetSaleQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
