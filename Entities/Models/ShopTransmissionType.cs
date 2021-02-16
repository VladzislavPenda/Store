using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ShopTransmissionType
    {
        [Column("transmissionId")]
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название типа трансиссии(максимальная длина 100 символов).")]
        public string type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
