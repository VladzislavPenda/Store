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
        IShopModelRepository ShopModel { get; }
        IUsersRepository User { get; }

        Task SaveAsync();
    }

}
