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
    class ShopEngineTypeRepository : RepositoryBase<ShopEngineType>, IShopEngineTypeRepository
    {
        public ShopEngineTypeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ShopEngineType>> GetAllEngineTypes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<ShopEngineType> GetEngineType(int engineId, bool trackChanges)
        {
            return await FindByCondition(c => c.id.Equals(engineId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateEngineType(ShopEngineType engineType) => Create(engineType);

        public async Task<IEnumerable<ShopEngineType>> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToListAsync();
        }
        public void DeleteEngineType(ShopEngineType shopEngineType)
        {
            Delete(shopEngineType);
        }
    }
}
