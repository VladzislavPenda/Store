using Contracts;
using Entities;
using Entities.DataTransferObjects.IncludeDTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    class ShopModelRepository : RepositoryBase<ShopModel>, IShopModelRepository
    {
        public ShopModelRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<List<ShopModel>> GetModelsAsyncAll(bool trackChanges)
        {
            var model = await FindAll(trackChanges)
                .ToListAsync();
            return model;
        }

        public async Task<PagedList<ShopModel>> GetModelsAsync(ModelsParameters modelsParametres, bool trackChanges)
        {
            var model = await FindAll(trackChanges)
                .ToListAsync();
            return PagedList<ShopModel>
                .ToPagedList(model, modelsParametres.PageNumber, modelsParametres.PageSize);
        }

        //public async Task<PagedList<ModelFullInfo>> GetAllIncludesAsync(ModelsParameters modelsParametres, bool trackChanges)
        //{
        //    var shopModels = await FindAll(trackChanges)
        //        .Include(c => c.MarkEnt)
        //        .Include(d => d.EngineType)
        //        .Include(f => f.DriveType)
        //        .Include(e => e.CarcaseType)
        //        .Include(t => t.TransmissionType)
        //        .Select(c => new ModelFullInfo
        //        {
        //            modelId = c.Id,
        //            model = c.Model,
        //            year = c.Year,
        //            price = c.Price,
        //            mileAge = c.MileAge,
        //            horsePower = c.HorsePower,
        //            engineType = c.EngineType.Name,
        //            carcaseType = c.CarcaseType.Name,
        //            driveType = c.DriveType.Name,
        //            transmission = c.TransmissionType.Name,
        //            markName = c.MarkEnt.Name,
        //            description = c.Description
        //        })
        //        .FilterModels(modelsParametres)
        //        .Search(modelsParametres.SearchTerm)
        //        .Sort(modelsParametres.OrderBy)
        //        .ToListAsync();

            
        //    return PagedList<ModelFullInfo>
        //        .ToPagedList(shopModels, modelsParametres.PageNumber, modelsParametres.PageSize);
        //}
        
        public async Task<IEnumerable<ShopModel>> GetAllShopModels(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(c => c.Year)
            .ToListAsync();
        }

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

        public async Task<ShopModel> GetModel(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(id), trackChanges)

                .SingleOrDefaultAsync();
        }

        public void CreateModel(int markId, Guid engineId, Guid carcaseId, Guid driveId, Guid transmissionId, ShopModel shopModel)
        {
            //shopModel.EngineTypeId = engineId;
            //shopModel.DriveTypeId = driveId;
            //shopModel.CarcaseTypeId = carcaseId;
            //shopModel.MarkId = markId;
            //shopModel.TransmissionTypeId = transmissionId;
            Create(shopModel);
        }

        public void DeleteModel(ShopModel shopModel)
        {
            Delete(shopModel);
        }
    }
}
