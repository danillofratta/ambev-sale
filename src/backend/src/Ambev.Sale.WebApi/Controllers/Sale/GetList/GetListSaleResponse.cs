using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Core.Domain.Enum;

namespace Ambev.Sale.WebApi.Controllers.Sale.GetList
{
    public class GetListSaleResponse
    {
        public Guid id { get; set; }
        public int Number { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public SaleStatus Status { get; set; }

        public decimal TotalAmount { get; set; }

        public List<GetSaleItemDto> SaleItems { get; set; }
    }
}
