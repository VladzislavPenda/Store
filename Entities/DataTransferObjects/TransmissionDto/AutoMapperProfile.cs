using Entities.DataTransferObjects.TransmissionDTO;
using Entities.Models;

namespace Entities.DataTransferObjects.Transmission
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShopTransmissionType, TransmissionDto>();
            CreateMap<TransmissionDto, ShopTransmissionType>();
            CreateMap<TransmissionForCreationDto, ShopTransmissionType>();
            CreateMap<TransmissionForUpdatingDto, ShopTransmissionType>();
        }
    }
}
