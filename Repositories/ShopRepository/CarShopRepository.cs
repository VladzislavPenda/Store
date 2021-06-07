using Contracts.IShopRepository;
using Entities;
using Entities.DataTransferObjects.CarShopDto;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ShopRepository
{
    public class CarShopRepository: RepositoryBase<CarShop>, ICarShopRepository
    {
        public CarShopRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        {

        }

        public async Task<IEnumerable<CarShop>> GetAllShops(bool trackChanges)
        {
            return await FindAll(trackChanges: false).ToListAsync();
        }

        public async Task<CarShop> GetShopWithEmployees(Guid companyGuid, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(companyGuid), trackChanges)
                .Include(c => c.Employees)
                .ThenInclude(d => d.Profession)
                .FirstOrDefaultAsync();
        }

        public async Task<CarShop> GetShopById(Guid companyGuid, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(companyGuid), trackChanges)
                .FirstOrDefaultAsync();
        }

        public void CreateShop(CarShop carShop) => Create(carShop);
        public void DeleteShop(CarShop carShop) => Delete(carShop);
    }
}
