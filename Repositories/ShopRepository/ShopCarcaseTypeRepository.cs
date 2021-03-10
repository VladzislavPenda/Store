using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    class ShopCarcaseTypeRepository : RepositoryBase<ShopCarcaseType>, IShopCarcaseTypeRepository
    {
        public ShopCarcaseTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<ShopCarcaseType> GetAllCarcaseTypes(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public ShopCarcaseType GetCarcaseType(int id, bool trackChanges)
        {
            return FindByCondition(c => c.id.Equals(id), trackChanges).SingleOrDefault();
        }

        public void CreateCarcaseType(ShopCarcaseType shopCarcaseType) => Create(shopCarcaseType);
    }
}
