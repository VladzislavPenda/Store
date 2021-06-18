using Entities.DataTransferObjects.IncludeDTO;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopModelRepository
    {
        Task<List<ShopModel>> GetModelsAsyncAll(bool trackChanges);
        Task<PagedList<ShopModel>> GetModelsAsync(ModelsParameters modelsParametres, bool trackChanges);
        Task<IEnumerable<ShopModel>> GetAllShopModels(bool trackChanges);
        //Task<PagedList<ModelFullInfo>> GetAllIncludesAsync(ModelsParameters modelsParametres, bool trackChanges);
        Task<ShopModel> GetModel(int id, bool trackChanges);
        //Task<ModelFullInfo> GetModelFullInfo(int id, bool trackChanges);
        void CreateModel(ShopModel shopModel, Guid modelId, Guid storageId);
        void DeleteModel(ShopModel shopModel);
    }
}
