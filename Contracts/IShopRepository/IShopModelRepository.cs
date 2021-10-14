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
        //Task<List<ShopModel>> GetModelsAsyncAll(bool trackChanges);
        //Task<PagedList<ShopModel>> GetModelsAsync(ModelsParameters modelsParametres, bool trackChanges);
        Task<ShopModel[]> GetAllShopModelsAsync(bool trackChanges);
        Task<PagedModels> GetPagedModelsWithParamsAsync(ModelsParameters modelsParametres, bool trackChanges);
        Task<ShopModel> GetModelAsync(Guid id, bool trackChanges);
        //Task<ModelFullInfo> GetModelFullInfo(int id, bool trackChanges);
        void CreateModel(ShopModel shopModel, Guid modelId, Guid storageId);
        void DeleteModel(ShopModel shopModel);
    }
}
