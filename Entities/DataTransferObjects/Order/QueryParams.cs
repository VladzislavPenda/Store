using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Order
{
    public class QueryParams
    {
        public int PageNumber { get; set; }

        [Range(1, 50)]
        public int PageSize { get; set; }
    }
}
