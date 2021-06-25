using Contracts.IShopRepository;
using Entities;
using Entities.Models.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Ent> GetEntById(Guid entId)
        {
            return await FindByCondition(e => e.Id == entId, trackChanges: false).SingleOrDefaultAsync();
        }

        public void DeleteEnt(Ent ent)
        {
            Delete(ent);
        }
    }
}
