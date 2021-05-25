using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IShopRepository
{
    public interface IUsersRepository
    {
        Task<User> GetUser(string userId, bool trackChanges);
    }
}
