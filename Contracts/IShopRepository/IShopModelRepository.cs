using Entities.Models;
using Entities.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopModelRepository
    {
        Task<PagedList<ShopModel>> GetModelsAsync(ModelsParameters modelsParametres, bool trackChanges);
        Task<IEnumerable<ShopModel>> GetAllShopModels(bool trackChanges);
        IEnumerable<ShopModel> GetAllIncludes(bool trackChanges);
        Task<ShopModel> GetModel(int id, bool trackChanges);
        void CreateModel(int markId, int engineId, int carcaseId, int driveId, int transmissionId, ShopModel shopModel);
        void DeleteModel(ShopModel shopModel);
    }
}
