using Ambev.Sale.Core.Application.Sales.Create;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

namespace Ambev.Sale.WebApi.Controllers.Sale.Create
{
    public class CreateSaleProfile : Profile
    {
       public CreateSaleProfile()
        {
            CreateMap<CreateSaleRequest, CreateSaleCommand>();
            CreateMap<CreateSaleResult, CreateSaleResponse>();
        }
    }
}
