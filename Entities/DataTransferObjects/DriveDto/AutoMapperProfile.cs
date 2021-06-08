using Entities.DataTransferObjects.DriveDTO;
using Entities.Models;

namespace Entities.DataTransferObjects.Drive
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ShopDriveType, DriveDto>();
            CreateMap<DriveDto, ShopDriveType>();
            CreateMap<DriveForCreationDto, ShopDriveType>();
            CreateMap<DriveForUpdatingDto, ShopDriveType>();
        }
    }
}
