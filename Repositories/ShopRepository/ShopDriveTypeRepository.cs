using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    class ShopDriveTypeRepository : RepositoryBase<ShopDriveType>, IShopDriveTypeRepository
    {
        public ShopDriveTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<ShopDriveType> GetAllDriveTypes(bool trackchanges)
        {
            return FindAll(trackchanges).ToList();
        }

        public ShopDriveType GetDriveType(int driveTypeId, bool trackchanges)
        {
            return FindByCondition(c => c.id.Equals(driveTypeId), trackchanges).SingleOrDefault();
        }

        public void CreateDriveType(ShopDriveType shopDriveType) => Create(shopDriveType);

        public IEnumerable<ShopDriveType> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToList();
        }
    }
}
