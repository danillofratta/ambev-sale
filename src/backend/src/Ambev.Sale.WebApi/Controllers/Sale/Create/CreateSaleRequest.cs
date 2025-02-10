using Ambev.Sale.Core.Application.Sales.Dto;

namespace Ambev.Sale.WebApi.Controllers.Sale.Create
{
    public class CreateSaleRequest
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public List<CreateSaleItemDto> SaleItems { get; set; } = new();
    }
}
