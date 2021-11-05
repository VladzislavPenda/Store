using Entities.DataTransferObjects.UserDTO;
using Entities.DataTransferObjects.UserInfo;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserInfoDto>();
        }
    }
}
