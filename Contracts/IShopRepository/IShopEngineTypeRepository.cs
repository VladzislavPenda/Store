using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IShopEngineTypeRepository
    {
        IEnumerable<ShopEngineType> GetAllEngineTypes(bool trackChanges);
        ShopEngineType GetEngineType(int engineId, bool trackChanges);
        void CreateEngineType(ShopEngineType engineType);
        IEnumerable<ShopEngineType> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteEngineType(ShopEngineType shopEngineType);
    }
}
