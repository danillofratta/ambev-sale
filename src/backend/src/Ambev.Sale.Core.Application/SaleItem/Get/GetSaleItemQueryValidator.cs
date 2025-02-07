using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;


namespace Ambev.Sale.Core.Application.SalesItem.Get
{
    public class GetSaleItemQueryValidator : AbstractValidator<GetSaleItemQuery>
    {
        public GetSaleItemQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
