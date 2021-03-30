using Entities.DataTransferObjects.IncludeDTO;
using System.Linq.Dynamic.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

        public static IQueryable<ModelFullInfo> Sort(this IQueryable<ModelFullInfo> employees, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return employees.OrderBy(e => e.price);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(ModelFullInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return employees.OrderBy(e => e.price);
            return employees.OrderBy(orderQuery);
        }
    }
}
