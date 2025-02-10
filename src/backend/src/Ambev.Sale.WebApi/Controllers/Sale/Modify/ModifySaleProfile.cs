using Ambev.Sale.Core.Application.Sales.Modify;
using AutoMapper;

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
