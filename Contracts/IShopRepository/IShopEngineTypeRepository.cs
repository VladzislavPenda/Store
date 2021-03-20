using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopEngineTypeRepository
    {
        Task<IEnumerable<ShopEngineType>> GetAllEngineTypes(bool trackChanges);
        Task<ShopEngineType> GetEngineType(int engineId, bool trackChanges);
        void CreateEngineType(ShopEngineType engineType);
        Task<IEnumerable<ShopEngineType>> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteEngineType(ShopEngineType shopEngineType);
    }
}
