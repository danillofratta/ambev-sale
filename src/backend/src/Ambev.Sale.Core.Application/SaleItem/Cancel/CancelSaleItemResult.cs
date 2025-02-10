using MediatR;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemResult : INotification
    {
        public Guid id { get; set; }
    }
}
