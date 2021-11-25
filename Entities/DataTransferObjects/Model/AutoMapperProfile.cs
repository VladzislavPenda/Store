
using Entities.DataTransferObjects.QueryModelDto;
using Entities.Models;
using Entities.Models.Product;
using System.Linq;

namespace Entities.DataTransferObjects.Model
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShopModel, ModelDto>();
            CreateMap<ModelForCreationDto, ShopModel>();
            CreateMap<QueryModelForUpdating, ShopModel>();
            CreateMap<QueryModelForCreating, ShopModel>();
            CreateMap<ShopModel, ModelShortDto>()
                .ForMember(e => e.Photos, e => e.MapFrom(e => e.Meshes.Where(c => c.Ent.Type == EntType.Picture).Select(e => e.Ent.Id)));

            CreateMap<ShopModel, FullModelInfo>()
                .ForMember(e => e.Photos, e => e.MapFrom(e => e.Meshes.Where(c => c.Ent.Type == EntType.Picture).Select(e => e.Ent.Id)))
                .ForMember(e => e.Characteristics, e => e.MapFrom(e => e.Meshes.Where(c => c.Ent.Type != EntType.Picture).Select(c => new Characterstic { Name = c.Ent.Type.ToString(), Value = c.Ent.Value }).ToArray()));
        }
    }
}
