using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShopMarkRepository
    {
        Task<IEnumerable<ShopMark>> GetAllMarks(bool trackChanges);
        Task<ShopMark> GetMark(int markId, bool trackChanges);
        void CreateMark(ShopMark shopMark);
        Task<IEnumerable<ShopMark>> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void DeleteMark(ShopMark shopMark);
    }
}
