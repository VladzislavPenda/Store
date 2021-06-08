using Entities.DataTransferObjects.EngineDTO;
using Entities.Models;

namespace Entities.DataTransferObjects.Engine
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShopEngineType, EngineDto>();
            CreateMap<EngineDto, ShopEngineType>();
            CreateMap<EngineForCreationDto, ShopEngineType>();
            CreateMap<EngineForUpdatingDto, ShopEngineType>();
        }
    }
}
