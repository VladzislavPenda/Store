using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class ShopCarcaseTypeRepository : RepositoryBase<ShopCarcaseType>, IShopCarcaseTypeRepository
    {
        public ShopCarcaseTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ShopCarcaseType>> GetAllCarcaseTypes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<ShopCarcaseType> GetCarcaseType(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateCarcaseType(ShopCarcaseType shopCarcaseType) => Create(shopCarcaseType);

        public async Task<IEnumerable<ShopCarcaseType>> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();
        }

        public void DeleteCarcaseType(ShopCarcaseType shopCarcaseType) => Delete(shopCarcaseType);
    }
}
