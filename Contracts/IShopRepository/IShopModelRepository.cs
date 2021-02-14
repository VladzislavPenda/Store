﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IShopModelRepository
    {
        IEnumerable<ShopModel> GetAllShopModels(bool trackChanges);
        ShopModel GetModel(int id, bool trackChanges);
    }
}
