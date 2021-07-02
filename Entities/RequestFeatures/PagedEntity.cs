using System;
using System.Linq;

namespace Entities.RequestFeatures
{
    public class PagedEntity<T>
    {
        public MetaData MetaData { get; set; }
        public T[] Models { get; set; }
        public PagedEntity(T[] models, int count, int pageNumber, int pageSize)
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

        public static PagedEntity<T> ToPagedModels(T[] source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToArray();
            return new PagedEntity<T>(items, count, pageNumber, pageSize);
        }
    }
}
