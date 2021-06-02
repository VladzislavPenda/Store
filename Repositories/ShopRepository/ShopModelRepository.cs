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
        private readonly RepositoryContext _context;
        public ShopModelRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _context = repositoryContext;
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
                    modelId = c.id,
                    model = c.model,
                    year = c.year,
                    price = c.price,
                    mileAge = c.mileAge,
                    horsePower = c.horsePower,
                    country = c.ShopMark.country,
                    engineType = c.ShopEngineType.type,
                    carcaseType = c.ShopCarcaseType.type,
                    driveType = c.ShopDriveType.type,
                    transmission = c.ShopTransmissionType.type,
                    markName = c.ShopMark.markNum,
                    description = c.description,
                    pathToPicture = c.pathToPicture,
                    phoneNumber = c.phoneNumber
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
            .OrderBy(c => c.year)
            .ToListAsync();
        }

        public async Task<ModelFullInfo> GetModelFullInfo(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.id.Equals(id), trackChanges)
                .Include(c => c.ShopMark)
                .Include(d => d.ShopEngineType)
                .Include(f => f.ShopDriveType)
                .Include(e => e.ShopCarcaseType)
                .Include(t => t.ShopTransmissionType)
                .Select(c => new ModelFullInfo
                {
                    modelId = c.id,
                    model = c.model,
                    price = c.price,
                    mileAge = c.mileAge,
                    year = c.year,
                    horsePower = c.horsePower,
                    country = c.ShopMark.country,
                    engineType = c.ShopEngineType.type,
                    carcaseType = c.ShopCarcaseType.type,
                    driveType = c.ShopDriveType.type,
                    transmission = c.ShopTransmissionType.type,
                    markName = c.ShopMark.markNum,
                    description = c.description,
                    pathToPicture = c.pathToPicture,
                    phoneNumber = c.phoneNumber
                })
                .SingleOrDefaultAsync();
        }

        public async Task<ShopModel> GetModel(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.id.Equals(id), trackChanges)

                .SingleOrDefaultAsync();
        }

        public void CreateModel(int markId, int engineId, int carcaseId, int driveId, int transmissionId, ShopModel shopModel)
        {
            shopModel.engineTypeId = engineId;
            shopModel.driveTypeId = driveId;
            shopModel.carcaseTypeId = carcaseId;
            shopModel.markId = markId;
            shopModel.transmissionId = transmissionId;
            Create(shopModel);
        }

        public void DeleteModel(ShopModel shopModel)
        {
            Delete(shopModel);
        }
    }
}
