using Contracts.IShopRepository;
using Entities;
using Entities.Models.Product;

using System.Collections.Generic;
using System.Linq;

namespace Repositories.ShopRepository
{
    public class EntRepository : RepositoryBase<Ent>, IEntRepository
    {
        public EntRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEnt(Ent ent)
        {
            Create(ent);
        }

        public void CreateEntRange(IEnumerable<Ent> ents)
        {
            CreateRange(ents);
        }

        public IQueryable<Ent> GetEntsByType(EntType entType)
        {
            return FindByCondition(e => e.Type == entType, trackChanges: false);
        }
    }
}
