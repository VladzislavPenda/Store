using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class ShopDriveTypeRepository : RepositoryBase<ShopDriveType>, IShopDriveTypeRepository
    {
        public ShopDriveTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
