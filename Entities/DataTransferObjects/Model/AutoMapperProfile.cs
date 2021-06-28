﻿
using Entities.DataTransferObjects.QueryModelDto;
using Entities.Models;

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
        }
    }
}
