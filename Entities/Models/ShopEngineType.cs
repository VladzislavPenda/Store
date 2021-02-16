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

        [StringLength(100, ErrorMessage = "Слишком длинное название для типа двигателя(максимальная длина 100 символов).")]
        public string type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
