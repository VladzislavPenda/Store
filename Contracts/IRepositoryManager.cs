using Contracts;
using Contracts.IShopRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IShopCarcaseTypeRepository ShopCarcaseType { get; }
        IShopDriveTypeRepository ShopDriveType { get; }
        IShopEngineTypeRepository ShopEngineType { get; }
        IShopMarkRepository ShopMark { get; }
        IShopModelRepository ShopModel { get; }
        IShopTransmissionTypeRepository ShopTransmissionType { get; }
        IUsersRepository User { get; }

        Task SaveAsync();
    }

}
