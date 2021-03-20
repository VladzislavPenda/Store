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
    class ShopMarkRepository : RepositoryBase<ShopMark>, IShopMarkRepository
    {
        public ShopMarkRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public async Task<IEnumerable<ShopMark>> GetAllMarks(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(c => c.markNum)
            .ToListAsync();
        }

        public async Task<ShopMark> GetMark(int markId, bool trackChanges)
        {
            return await FindByCondition(c => c.id.Equals(markId), trackChanges)
                .SingleOrDefaultAsync();
        }

        public void CreateMark(ShopMark shopMark) => Create(shopMark);

        public async Task<IEnumerable<ShopMark>> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.id), trackChanges)
                .ToListAsync();
        }

        public void DeleteMark(ShopMark shopMark)
        {
            Delete(shopMark);
        }
    }
}
