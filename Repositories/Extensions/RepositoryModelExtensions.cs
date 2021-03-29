using Entities.DataTransferObjects.IncludeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extensions
{
    public static class RepositoryModelExtensions
    {
        public static IQueryable<ModelFullInfo> FilterModels(this IQueryable<ModelFullInfo> model, uint minPrice, uint maxPrice)
        {
            return model.Where(m => (m.price >= minPrice) && (m.price <= maxPrice));
        }

        public static IQueryable<ModelFullInfo> Search(this IQueryable<ModelFullInfo> model, string searchItem)
        {
            if (string.IsNullOrWhiteSpace(searchItem))
                return model;

            var lowerCase = searchItem.Trim().ToLower();

            return model.Where(m => m.markName.ToLower().Contains(lowerCase));
        }
    }
}
