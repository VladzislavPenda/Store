using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class ShopCarcaseTypeRepository : RepositoryBase<ShopCarcaseType>, IShopCarcaseTypeRepository
    {
        public ShopCarcaseTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
