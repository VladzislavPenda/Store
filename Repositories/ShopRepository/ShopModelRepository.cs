using Contracts;
using Entities;
using Entities.DataTransferObjects.IncludeDTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Extensions;
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

        public async Task<PagedList<ModelFullInfo>> GetAllIncludesAsync(ModelsParameters modelsParametres, bool trackChanges)
        {
            var shopModels = await FindAll(trackChanges)
                .Include(c => c.ShopMark)
                .Include(d => d.ShopEngineType)
                .Include(f => f.ShopDriveType)
                .Include(e => e.ShopCarcaseType)
                .Include(t => t.ShopTransmissionType)
                .Select(c => new ModelFullInfo
                {
                    modelId = c.Id,
                    model = c.Model,
                    year = c.Year,
                    price = c.Price,
                    mileAge = c.MileAge,
                    horsePower = c.HorsePower,
                    country = c.ShopMark.Country,
                    engineType = c.ShopEngineType.Type,
                    carcaseType = c.ShopCarcaseType.Type,
                    driveType = c.ShopDriveType.Type,
                    transmission = c.ShopTransmissionType.Type,
                    markName = c.ShopMark.Name,
                    description = c.Description,
                    phoneNumber = c.PhoneNumber
                })
                .FilterModels(modelsParametres)
                .Search(modelsParametres.SearchTerm)
                .Sort(modelsParametres.OrderBy)
                .ToListAsync();

            
            return PagedList<ModelFullInfo>
                .ToPagedList(shopModels, modelsParametres.PageNumber, modelsParametres.PageSize);
        }
        
        public async Task<IEnumerable<ShopModel>> GetAllShopModels(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(c => c.Year)
            .ToListAsync();
        }

        public async Task<ModelFullInfo> GetModelFullInfo(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(id), trackChanges)
                .Include(c => c.ShopMark)
                .Include(d => d.ShopEngineType)
                .Include(f => f.ShopDriveType)
                .Include(e => e.ShopCarcaseType)
                .Include(t => t.ShopTransmissionType)
                .Select(c => new ModelFullInfo
                {
                    modelId = c.Id,
                    model = c.Model,
                    price = c.Price,
                    mileAge = c.MileAge,
                    year = c.Year,
                    horsePower = c.HorsePower,
                    country = c.ShopMark.Country,
                    engineType = c.ShopEngineType.Type,
                    carcaseType = c.ShopCarcaseType.Type,
                    driveType = c.ShopDriveType.Type,
                    transmission = c.ShopTransmissionType.Type,
                    markName = c.ShopMark.Name,
                    description = c.Description,
                    phoneNumber = c.PhoneNumber
                })
                .SingleOrDefaultAsync();
        }

        public async Task<ShopModel> GetModel(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(id), trackChanges)

                .SingleOrDefaultAsync();
        }

        public void CreateModel(int markId, int engineId, int carcaseId, int driveId, int transmissionId, ShopModel shopModel)
        {
            shopModel.EngineTypeId = engineId;
            shopModel.DriveTypeId = driveId;
            shopModel.CarcaseTypeId = carcaseId;
            shopModel.MarkId = markId;
            shopModel.TransmissionTypeId = transmissionId;
            Create(shopModel);
        }

        public void DeleteModel(ShopModel shopModel)
        {
            Delete(shopModel);
        }
    }
}
