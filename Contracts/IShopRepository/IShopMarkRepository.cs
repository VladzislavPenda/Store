using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IShopMarkRepository
    {
        IEnumerable<ShopMark> GetAllMarks(bool trackChanges);
    }
}
