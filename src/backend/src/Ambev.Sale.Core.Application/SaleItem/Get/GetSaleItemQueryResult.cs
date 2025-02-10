using Ambev.Sale.Core.Domain.Enum;


namespace Ambev.Sale.Core.Application.SalesItem.Get
{
    public class GetSaleItemQueryResult
    {
        public Guid id { get; set; }
        public Guid SaleId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }

        public SaleItemStatus Status { get; set; }
    }
}
