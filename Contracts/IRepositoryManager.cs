using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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

        void Save();
    }

}
