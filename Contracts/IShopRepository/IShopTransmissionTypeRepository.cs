using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IShopTransmissionTypeRepository
    {
        IEnumerable<ShopTransmissionType> GetAllTransmissionTypes(bool trackChanges);
        ShopTransmissionType GetTransmissionType(int driveTypeId, bool trackChanges);
        void CreateTransmissionType(ShopTransmissionType shopTransmissionType);
        IEnumerable<ShopTransmissionType> GetByIds(IEnumerable<int> ids, bool trackChanges);
    }
}
