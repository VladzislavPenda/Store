using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IShopDriveTypeRepository
    {
        IEnumerable<ShopDriveType> GetAllDriveTypes(bool trackChanges);
        ShopDriveType GetDriveType(int driveTypeId, bool trackChanges);
        void CreateDriveType(ShopDriveType shopDriveType);
        IEnumerable<ShopDriveType> GetByIds(IEnumerable<int> ids, bool trackChanges);

    }
}
