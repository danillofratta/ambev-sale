using Ambev.Sale.Core.Application.Sales.Dto;

namespace Ambev.Sale.WebApi.Controllers.Sale.GetList;

public class GetListSaleRequest
{
    public Guid  Id { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;

    public string BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;

    public List<GetSaleItemDto> Itens { get; set; }
}

