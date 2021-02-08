using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ShopTransmissionType
    {
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название типа трансиссии(максимальная длина 100 символов).")]
        public string type { get; set; }

        public virtual List<ShopModel> ShopModels { get; set; }
    }
}
