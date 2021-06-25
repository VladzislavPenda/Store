using Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IShopRepository
{
    public interface IEntRepository
    {
        void CreateEnt(Ent ent);
        void CreateEntRange(IEnumerable<Ent> ents);
        IQueryable<Ent> GetEntsByType(EntType entType);
        void DeleteEnt(Ent ent);
        Task<Ent> GetEntById(Guid entId);
       
    }
}
