using Ambev.Sale.Core.Application.Sales.Dto;

namespace Ambev.Sale.WebApi.Controllers.Sale.Modify
{
    public class ModifySaleRequest
    {
        public Guid  Id { get; set; }
        public int Number { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public List<ModifySaleItemDto> SaleItems { get; set; } = new();
    }
}
