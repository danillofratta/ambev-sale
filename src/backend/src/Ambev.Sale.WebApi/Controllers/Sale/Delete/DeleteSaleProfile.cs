using Ambev.Sale.Core.Application.Sales.Delete;
using AutoMapper;

namespace Ambev.Sale.WebApi.Controllers.Sale.Delete
{
    public class DeleteSaleProfile : Profile
    {
       public DeleteSaleProfile()
        {
            CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
            CreateMap<DeleteSaleResult, DeleteSaleResponse>();
        }
    }
}
