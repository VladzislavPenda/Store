using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopDriveTypeRepository
    {
        Task<IEnumerable<ShopDriveType>> GetAllDriveTypes(bool trackChanges);
        Task<ShopDriveType> GetDriveType(int driveTypeId, bool trackChanges);
        void CreateDriveType(ShopDriveType shopDriveType);
        Task<IEnumerable<ShopDriveType>> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteDriveType(ShopDriveType shopDriveType);

    }
}
