using Contracts.IShopRepository;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ShopRepository
{
    public class UsersRepository: RepositoryBase<User>, IUsersRepository
    {
        private readonly RepositoryContext _context;
        public UsersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _context = repositoryContext;
        }
        public async Task<User> GetUser(string userId, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(userId), trackChanges).FirstOrDefaultAsync();
        }
    }
}
