using Entities.DataTransferObjects.CarcaseDTO;
using Entities.Models;

namespace Entities.DataTransferObjects.Carcase
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShopCarcaseType, CarcaseDto>();
            CreateMap<CarcaseDto, ShopCarcaseType>();
            CreateMap<CarcaseForCreationDto, ShopCarcaseType>();
            CreateMap<CarcaseForUpdatingDto, ShopCarcaseType>();
        }
    }
}
