﻿using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    class ShopModelRepository : RepositoryBase<ShopModel>, IShopModelRepository
    {
        private readonly RepositoryContext _context;
        public ShopModelRepository(RepositoryContext repositoryContext)
            : base (repositoryContext)
        {
            _context = repositoryContext;
        }
        
        public IEnumerable<ShopModel> GetAllShopModels(bool trackChanges)
        {
            return FindAll(trackChanges)
            .OrderBy(c => c.year)
            .ToList();
        }

        public ShopModel GetModel(int id, bool trackchanges)
        {
            return FindByCondition(c => c.id.Equals(id), trackchanges)
                .SingleOrDefault();
        }
    }
}
