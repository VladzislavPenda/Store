using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ShopEngineType
    {
        [Column("engineTypeId")]
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "The name for the engine type is too long (maximum length 100 characters).")]
        public string type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
