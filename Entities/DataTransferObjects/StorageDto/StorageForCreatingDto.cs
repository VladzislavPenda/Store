using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Storages
{
    public class StorageForCreatingDto
    {
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public TimeSpan OpenTime { get; set; }
        [Required]
        public TimeSpan CloseTime { get; set; }
    }
}
