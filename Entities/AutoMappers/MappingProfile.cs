using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.EngineDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<ShopModel, modelDTO>()
            //    .ForMember(c => c.year, opt => opt.MapFrom(x => (int)x.year))
            //    .ForMember(c => c.horsePower, opt => opt.MapFrom(x => (int)x.horsePower));

            CreateMap<ShopModel, ModelDTO>();
            CreateMap<ShopMark, MarkDTO>();
            CreateMap<MarkForCreationDTO, ShopMark>();
            CreateMap<ShopEngineType, EngineDTO>();
        }
    }
}
