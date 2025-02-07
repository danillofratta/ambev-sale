using Ambev.Sale.Core.Application.Sales.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Application.Sales.GetList;
 public class GetListSaleQuery : IRequest<PagedResult<GetListSaleQueryResult>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? OrderBy { get; set; }
    public bool IsDescending { get; set; }
}
