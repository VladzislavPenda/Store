using Entities.Models.Shop;
using System;
using System.Threading.Tasks;

namespace Contracts.IShopRepository
{
    public interface IStorageRepository
    {
        Task<Guid> GetStorageByAddress(string address);
        Task<Storage[]> GetStoragesAsync();
        Task<Storage> GetStorageById(Guid id);
        void DeleteStorage(Storage storage);
        void CreateStorage(Storage storage);
    }
}
