using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.CarcaseDTO;
using Entities.DataTransferObjects.CarShopDto;
using Entities.DataTransferObjects.DriveDTO;
using Entities.DataTransferObjects.EngineDTO;
using Entities.DataTransferObjects.MarkDTO;
using Entities.DataTransferObjects.TransmissionDTO;
using Entities.DataTransferObjects.UserDTO;
using Entities.Models;

namespace Entities.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShopModel, ModelDto>();
            CreateMap<ModelForCreationDto, ShopModel>();
            CreateMap<ModelForUpdatingDto, ShopModel>();

            CreateMap<ShopMark, MarkDto>();
            CreateMap<MarkDto, ShopMark>();
            CreateMap<MarkForCreationDto, ShopMark>();
            CreateMap<MarkForUpdatingDto, ShopMark>();

            CreateMap<ShopEngineType, EngineDto>();
            CreateMap<EngineDto, ShopEngineType>();
            CreateMap<EngineForCreationDto, ShopEngineType>();
            CreateMap<EngineForUpdatingDto, ShopEngineType>();

            CreateMap<ShopDriveType, DriveDto>();
            CreateMap<DriveDto, ShopDriveType>();
            CreateMap<DriveForCreationDto, ShopDriveType>();
            CreateMap<DriveForUpdatingDto, ShopDriveType>();

            CreateMap<ShopCarcaseType, CarcaseDto>();
            CreateMap<CarcaseDto, ShopCarcaseType>();
            CreateMap<CarcaseForCreationDto, ShopCarcaseType>();
            CreateMap<CarcaseForUpdatingDto, ShopCarcaseType>();

            CreateMap<ShopTransmissionType, TransmissionDto>();
            CreateMap<TransmissionDto, ShopTransmissionType>();
            CreateMap<TransmissionForCreationDto, ShopTransmissionType>();
            CreateMap<TransmissionForUpdatingDto, ShopTransmissionType>();

            CreateMap<UserForRegistrationDto, User>();

            CreateMap<CarShop, CarShopDto>()
                .PreserveReferences();

            CreateMap<CarShopForCreatingDto, CarShop>();
            CreateMap<CarShopForUpdatingDto, CarShop>();

        }
    }
}
