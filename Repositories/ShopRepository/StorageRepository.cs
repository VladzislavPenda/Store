using Contracts.IShopRepository;
using Entities;
using Entities.Models.Shop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.ShopRepository
{
    public class StorageRepository: RepositoryBase<Storage>, IStorageRepository
    {
        public StorageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Storage[]> GetStoragesAsync()
        {
            return await FindAll(trackChanges: false)
                .ToArrayAsync();
        }

        public async Task<Guid> GetStorageByAddress(string address)
        {
            return await FindByCondition(e => e.Address == address, trackChanges: false)
                .Select(e => e.Id)
                .SingleOrDefaultAsync();
        }

        public async Task<Storage> GetStorageById(Guid id)
        {
            return await FindByCondition(e => e.Id == id, trackChanges: false)
                .SingleOrDefaultAsync();
        }

        public async void DeleteStorage(Storage storage)
        {
            Delete(storage);
        }

        public async void CreateStorage(Storage storage)
        {
            Create(storage);
        }
    }
}
