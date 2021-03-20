using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    class ShopModelRepository : RepositoryBase<ShopModel>, IShopModelRepository
    {
        private readonly RepositoryContext _context;
        public ShopModelRepository(RepositoryContext repositoryContext)
            : base (repositoryContext)
        {
            _context = repositoryContext;
        }

        public IEnumerable<ShopModel> GetAllIncludes(bool trackChanges)
        {
            //return _context.Set<ShopModel>()
            
            IEnumerable<ShopModel> shopModels = _context.ShopModels
                .Include(c => c.ShopMark)
                .Include(d => d.ShopEngineType)
                .Include(e => e.ShopCarcaseType)
                .Include(f => f.ShopMark)
                .Include(g => g.ShopTransmissionType)
                .ToList();
                


            return shopModels;
        }

        //public IEnumerable<ShopModel> Get(bool trackChanges, IEnumerable<ModelDTO> models)
        //{
        //    IEnumerable<ShopModel> shopModels = _context.Set<ModelDTO>().Include(c => c.)
        //}
        
        public async Task<IEnumerable<ShopModel>> GetAllShopModels(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(c => c.year)
            .ToListAsync();
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
