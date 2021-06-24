using Entities.Models.Product;

namespace Entities.DataTransferObjects.EntDto
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ent, EntResponseDto>();
        }
    }
}
