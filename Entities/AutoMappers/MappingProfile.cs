using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.CarcaseDTO;
using Entities.DataTransferObjects.DriveDTO;
using Entities.DataTransferObjects.EngineDTO;
using Entities.DataTransferObjects.TransmissionDTO;
using Entities.Models;

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
            CreateMap<EngineForCreationDTO, ShopEngineType>();

            CreateMap<ShopDriveType, DriveDTO>();
            CreateMap<DriveForCreationDTO, ShopDriveType>();

            CreateMap<ShopCarcaseType, CarcaseDTO>();
            CreateMap<CarcaseForCreationDTO, ShopCarcaseType>();

            CreateMap<ShopTransmissionType, TransmissionDTO>();
            CreateMap<TransmissionForCreationDTO, ShopTransmissionType>();
        }
    }
}
