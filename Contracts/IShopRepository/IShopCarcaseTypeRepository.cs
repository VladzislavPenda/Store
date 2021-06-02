using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopCarcaseTypeRepository
    {
        Task<IEnumerable<CarcaseType>> GetAllCarcaseTypes(bool trackChanges);
        Task<CarcaseType> GetCarcaseType(int id, bool trackChanges);
        void CreateCarcaseType(CarcaseType shopCarcaseType);
        Task<IEnumerable<CarcaseType>> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteCarcaseType(CarcaseType shopCarcaseType);
    }
}
