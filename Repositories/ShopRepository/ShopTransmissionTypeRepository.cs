using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    class ShopTransmissionTypeRepository : RepositoryBase<ShopTransmissionType>, IShopTransmissionTypeRepository
    {
        public ShopTransmissionTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<ShopTransmissionType> GetAllTransmissionTypes(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public ShopTransmissionType GetTransmissionType(int driveTypeId, bool trackChanges)
        {
            return FindByCondition(c => c.id.Equals(driveTypeId), trackChanges).SingleOrDefault();
        }

        public void CreateTransmissionType(ShopTransmissionType shopTransmissionType) => Create(shopTransmissionType);

        public IEnumerable<ShopTransmissionType> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToList();
        }
    }
}
