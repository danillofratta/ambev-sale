using MediatR;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemCommand : IRequest<CancelSaleItemResult>
    {
        public Guid id { get; set; }
    }
}
