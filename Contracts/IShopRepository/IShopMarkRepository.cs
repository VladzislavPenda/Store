using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IShopMarkRepository
    {
        IEnumerable<ShopMark> GetAllMarks(bool trackChanges);
        ShopMark GetMark(int markId, bool trackChanges);
        void CreateMark(ShopMark shopMark);

        IEnumerable<ShopMark> GetByIds(IEnumerable<int> ids, bool trackChanges); 
    }
}
