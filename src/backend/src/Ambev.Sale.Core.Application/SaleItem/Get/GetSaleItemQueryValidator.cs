using FluentValidation;


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
