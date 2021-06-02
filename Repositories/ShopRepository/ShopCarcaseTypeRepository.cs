using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class ShopCarcaseTypeRepository : RepositoryBase<CarcaseType>, IShopCarcaseTypeRepository
    {
        public ShopCarcaseTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<CarcaseType>> GetAllCarcaseTypes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<CarcaseType> GetCarcaseType(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateCarcaseType(CarcaseType shopCarcaseType) => Create(shopCarcaseType);

        public async Task<IEnumerable<CarcaseType>> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToListAsync();
        }

        public void DeleteCarcaseType(CarcaseType shopCarcaseType) => Delete(shopCarcaseType);
    }
}
