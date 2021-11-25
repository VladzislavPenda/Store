
using Entities.DataTransferObjects.Storages;
using Entities.Models;
using Entities.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Storage, StorageDto>()
                .ForMember(e => e.NumberOfCars, e => e.MapFrom(e => e.ShopModels.Count()));
                //.ForMember(e => e.OpenTime, e => e.MapFrom(e => mapTimeSpan(e.OpenTime)))
                //.ForMember(e => e.CloseTime, e => e.MapFrom(e => mapTimeSpan(e.CloseTime)));
        }

        //public string mapTimeSpan(TimeSpan time)
        //{
        //    string res = time.Hours + "." + time.Minutes + "." + time.Seconds;
        //    return res;
        //}
    }
}
