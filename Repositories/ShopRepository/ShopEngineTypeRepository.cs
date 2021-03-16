using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    class ShopEngineTypeRepository : RepositoryBase<ShopEngineType>, IShopEngineTypeRepository
    {
        public ShopEngineTypeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {

        }

        public IEnumerable<ShopEngineType> GetAllEngineTypes(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public ShopEngineType GetEngineType(int engineId, bool trackChanges)
        {
            return FindByCondition(c => c.id.Equals(engineId), trackChanges).SingleOrDefault();
        }

        public void CreateEngineType(ShopEngineType engineType) => Create(engineType);

        public IEnumerable<ShopEngineType> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToList();
        }
        public void DeleteEngineType(ShopEngineType shopEngineType)
        {
            Delete(shopEngineType);
        }
    }
}
