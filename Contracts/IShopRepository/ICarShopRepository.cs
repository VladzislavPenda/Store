using Entities.DataTransferObjects.CarShopDto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IShopRepository
{
    public interface ICarShopRepository
    {
        Task<IEnumerable<CarShop>> GetAllShops(bool trackChanges);
        Task<CarShop> GetShopWithEmployees(Guid companyGuid, bool trackChanges);
        Task<CarShop> GetShopById(Guid companyGuid, bool trackChanges);
        void CreateShop(CarShop carShop);
        void DeleteShop(CarShop carShop);
        //void Update(CarShop carShop);
    }
}
