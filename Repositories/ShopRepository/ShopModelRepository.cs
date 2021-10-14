using Contracts;
using Entities;
//using Entities.DataTransferObjects.IncludeDTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    class ShopModelRepository : RepositoryBase<ShopModel>, IShopModelRepository
    {
        private readonly RepositoryContext _repositoryContext; 
        public ShopModelRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<PagedModels> GetPagedModelsWithParamsAsync(ModelsParameters modelsParametres, bool trackChanges)
        {
            ShopModel[] shopModels = await _repositoryContext.ShopModels
                .Include(e => e.Meshes)
                .ThenInclude(c => c.Ent)
                .Where(e => e.IsActive == true)
                .FilterModels(modelsParametres)
                .ToArrayAsync();

            return PagedModels
                .ToPagedModels(shopModels, modelsParametres.PageNumber, modelsParametres.PageSize);
        }

        public async Task<ShopModel> GetModelAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges)
                .Include(e => e.Meshes)
                .ThenInclude(c => c.Ent)
                .Include(e => e.Storage)
                .Where(e => e.IsActive == true)
                .SingleOrDefaultAsync();
        }

        public async Task<ShopModel[]> GetAllShopModelsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .Include(e => e.Storage)
            .OrderBy(c => c.Year)
            .ToArrayAsync();
        }

        //public async Task<IEnumerable<ShopModel>> GetStatistic()
        //{
        //    IEnumerable<ShopModel> models = await FindAll(false).ToArrayAsync();

            
        //    return models;
        //}

        //public async Task<ModelFullInfo> GetModelFullInfo(int id, bool trackChanges)
        //{
        //    return await FindByCondition(c => c.Id.Equals(id), trackChanges)
        //        //.Include(c => c.MarkEnt)
        //        .Include(d => d.EngineType)
        //        .Include(f => f.DriveType)
        //        .Include(e => e.CarcaseType)
        //        .Include(t => t.TransmissionType)
        //        .Select(c => new ModelFullInfo
        //        {
        //            modelId = c.Id,
        //            model = c.Model,
        //            price = c.Price,
        //            mileAge = c.MileAge,
        //            year = c.Year,
        //            horsePower = c.HorsePower,
        //            engineType = c.EngineType.Name,
        //            carcaseType = c.CarcaseType.Name,
        //            driveType = c.DriveType.Name,
        //            transmission = c.TransmissionType.Name,
        //            markName = c.MarkEnt.Name,
        //            description = c.Description
        //        })
        //        .SingleOrDefaultAsync();
        //}

        public void CreateModel(ShopModel shopModel, Guid modelId, Guid storageId)
        {
            shopModel.Id = modelId;
            shopModel.StorageId = storageId;
            Create(shopModel);
        }

        public void DeleteModel(ShopModel shopModel)
        {
            Delete(shopModel);
        }
    }
}
