using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    class ShopDriveTypeRepository : RepositoryBase<ShopDriveType>, IShopDriveTypeRepository
    {
        public ShopDriveTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ShopDriveType>> GetAllDriveTypes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<ShopDriveType> GetDriveType(int driveTypeId, bool trackChanges)
        {
            return await FindByCondition(c => c.id.Equals(driveTypeId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateDriveType(ShopDriveType shopDriveType) => Create(shopDriveType);

        public async Task<IEnumerable<ShopDriveType>> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToListAsync();
        }

        public void DeleteDriveType(ShopDriveType shopDriveType) => Delete(shopDriveType);
    }
}
