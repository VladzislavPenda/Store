﻿using Entities.DataTransferObjects.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
        //Task<string> GetUserById(string userId);
    }
}
