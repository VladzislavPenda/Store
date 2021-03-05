using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    class ShopMarkRepository : RepositoryBase<ShopMark>, IShopMarkRepository
    {
        public ShopMarkRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public IEnumerable<ShopMark> GetAllMarks(bool trackChanges)
        {
            return FindAll(trackChanges)
            .OrderBy(c => c.markNum)
            .ToList();
        }

        public ShopMark GetMark(int markId, bool trackChanges)
        {
            return FindByCondition(c => c.id.Equals(markId), trackChanges)
                .SingleOrDefault();
        }

        public void CreateMark(ShopMark shopMark) => Create(shopMark);

    }
}
