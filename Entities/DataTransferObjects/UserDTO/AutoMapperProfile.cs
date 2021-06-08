using Entities.DataTransferObjects.UserDTO;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
