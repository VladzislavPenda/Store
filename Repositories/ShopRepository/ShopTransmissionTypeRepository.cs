using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    class ShopTransmissionTypeRepository : RepositoryBase<ShopTransmissionType>, IShopTransmissionTypeRepository
    {
        public ShopTransmissionTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ShopTransmissionType>> GetAllTransmissionTypes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<ShopTransmissionType> GetTransmissionType(int driveTypeId, bool trackChanges)
        {
            return await FindByCondition(c => c.id.Equals(driveTypeId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateTransmissionType(ShopTransmissionType shopTransmissionType) => Create(shopTransmissionType);

        public async Task<IEnumerable<ShopTransmissionType>> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToListAsync();
        }

        public void DeleteTransmissionType(ShopTransmissionType shopTransmissionType) => Delete(shopTransmissionType);
    }
}
