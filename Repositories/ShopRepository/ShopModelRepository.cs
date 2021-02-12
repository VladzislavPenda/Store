using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class ShopModelRepository : RepositoryBase<ShopModel>, IShopModelRepository
    {
        public ShopModelRepository(RepositoryContext repositoryContext)
            : base (repositoryContext)
        {

        }
    }
}
