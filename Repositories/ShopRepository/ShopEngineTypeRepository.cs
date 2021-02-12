using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class ShopEngineTypeRepository : RepositoryBase<ShopEngineType>, IShopEngineTypeRepository
    {
        public ShopEngineTypeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {

        }
    }
}
