using MediatR;

namespace Ambev.Sale.Core.Application.SalesItem.Get
{
    public class GetSaleItemQuery : IRequest<GetSaleItemQueryResult>
    {
        public Guid Id { get; set; }

        public GetSaleItemQuery(Guid id)
        {
            Id = id;
        }

    }
}
