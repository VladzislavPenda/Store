using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ShopEngineType
    {
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название для типа двигателя(максимальная длина 100 символов).")]
        public string type { get; set; }

        public virtual List<ShopModel> ShopModels { get; set; }
    }
}
