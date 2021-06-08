using Entities.Models;

namespace Entities.DataTransferObjects.CarShopDto
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarShop, CarShopDto>()
                .PreserveReferences();

            CreateMap<CarShopForCreatingDto, CarShop>();
            CreateMap<CarShopForUpdatingDto, CarShop>();
        }
        
    }
}
