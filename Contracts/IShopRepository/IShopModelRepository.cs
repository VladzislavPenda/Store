using Entities.DataTransferObjects.IncludeDTO;
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
        Task<PagedList<ModelFullInfo>> GetAllIncludesAsync(ModelsParameters modelsParametres, bool trackChanges);
        Task<ShopModel> GetModel(int id, bool trackChanges);
        Task<ModelFullInfo> GetModelFullInfo(int id, bool trackChanges);
        void CreateModel(int markId, int engineId, int carcaseId, int driveId, int transmissionId, ShopModel shopModel);
        void DeleteModel(ShopModel shopModel);
    }
}
