using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class ShopTransmissionTypeRepository : RepositoryBase<ShopTransmissionType>, IShopTransmissionTypeRepository
    {
        public ShopTransmissionTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
