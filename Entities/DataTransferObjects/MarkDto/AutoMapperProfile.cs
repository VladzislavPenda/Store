using Entities.DataTransferObjects.MarkDTO;
using Entities.Models;

namespace Entities.DataTransferObjects.Mark
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShopMark, MarkDto>();
            CreateMap<MarkDto, ShopMark>();
            CreateMap<MarkForCreationDto, ShopMark>();
            CreateMap<MarkForUpdatingDto, ShopMark>();
        }
    }
}
