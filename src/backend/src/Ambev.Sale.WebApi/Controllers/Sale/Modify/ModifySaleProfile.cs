using Ambev.Sale.Core.Application.Sales.Modify;
using Ambev.Sale.WebApi.Controllers.Sale.Modify;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

namespace Ambev.Sale.WebApi.Controllers.Sale.Modify
{
    public class ModifySaleProfile : Profile
    {
       public ModifySaleProfile()
        {
            CreateMap<ModifySaleRequest, ModifySaleCommand>();
            CreateMap<ModifySaleResult, ModifySaleResponse>();
        }
    }
}
