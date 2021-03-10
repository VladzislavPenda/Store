using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IShopCarcaseTypeRepository
    {
        IEnumerable<ShopCarcaseType> GetAllCarcaseTypes(bool trackChanges);
        ShopCarcaseType GetCarcaseType(int id, bool trackChanges);
        void CreateCarcaseType(ShopCarcaseType shopCarcaseType);
    }
}
