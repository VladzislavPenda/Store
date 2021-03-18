using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.CarcaseDTO;
using Entities.DataTransferObjects.DriveDTO;
using Entities.DataTransferObjects.EngineDTO;
using Entities.DataTransferObjects.MarkDTO;
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
            CreateMap<ModelForCreationDTO, ShopModel>();
            CreateMap<ModelForUpdatingDTO, ShopModel>();

            CreateMap<ShopMark, MarkDTO>();
            CreateMap<MarkDTO, ShopMark>();
            CreateMap<MarkForCreationDTO, ShopMark>();

            CreateMap<ShopEngineType, EngineDTO>();
            CreateMap<EngineDTO, ShopEngineType>();
            CreateMap<EngineForCreationDTO, ShopEngineType>();

            CreateMap<ShopDriveType, DriveDTO>();
            CreateMap<DriveDTO, ShopDriveType>();
            CreateMap<DriveForCreationDTO, ShopDriveType>();

            CreateMap<ShopCarcaseType, CarcaseDTO>();
            CreateMap<CarcaseDTO, ShopCarcaseType>();
            CreateMap<CarcaseForCreationDTO, ShopCarcaseType>();

            CreateMap<ShopTransmissionType, TransmissionDTO>();
            CreateMap<TransmissionDTO, ShopTransmissionType>();
            CreateMap<TransmissionForCreationDTO, ShopTransmissionType>();

            
        }
    }
}
