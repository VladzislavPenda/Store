using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class PagedModels
    {
        public MetaData MetaData { get; set; }
        public ShopModel[] Models { get; set; }
        public PagedModels(ShopModel[] models, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            Models = models;
        }

        public static PagedModels ToPagedModels (ShopModel[] source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToArray();
            return new PagedModels(items, count, pageNumber, pageSize);
        }
    }
}
