using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopCarcaseTypeRepository
    {
        Task<IEnumerable<ShopCarcaseType>> GetAllCarcaseTypes(bool trackChanges);
        Task<ShopCarcaseType> GetCarcaseType(int id, bool trackChanges);
        void CreateCarcaseType(ShopCarcaseType shopCarcaseType);
        Task<IEnumerable<ShopCarcaseType>> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteCarcaseType(ShopCarcaseType shopCarcaseType);
    }
}
