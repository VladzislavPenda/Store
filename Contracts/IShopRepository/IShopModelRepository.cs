using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopModelRepository
    {
        Task<IEnumerable<ShopModel>> GetAllShopModels(bool trackChanges);
        IEnumerable<ShopModel> GetAllIncludes(bool trackChanges);
        Task<ShopModel> GetModel(int id, bool trackChanges);
        void CreateModel(int markId, int engineId, int carcaseId, int driveId, int transmissionId, ShopModel shopModel);
        void DeleteModel(ShopModel shopModel);
    }
}
