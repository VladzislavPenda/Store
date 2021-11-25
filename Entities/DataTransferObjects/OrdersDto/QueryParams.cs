using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.OrderDto
{
    public class QueryParams
    {
        public int PageNumber { get; set; } = 1;

        [Range(1, 50)]
        public int PageSize { get; set; } = 10;
    }
}
