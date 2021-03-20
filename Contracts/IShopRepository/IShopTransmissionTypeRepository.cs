using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopTransmissionTypeRepository
    {
        Task<IEnumerable<ShopTransmissionType>> GetAllTransmissionTypes(bool trackChanges);
        Task<ShopTransmissionType> GetTransmissionType(int driveTypeId, bool trackChanges);
        void CreateTransmissionType(ShopTransmissionType shopTransmissionType);
        Task<IEnumerable<ShopTransmissionType>> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteTransmissionType(ShopTransmissionType shopTransmissionType);
    }
}
