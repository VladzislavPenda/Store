using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ShopMark
    {
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название марки авто(максимальная длина 100 символов).")]
        public string markNum { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название страны производителя(максимальная длина 100 символов).")]
        public string country { get; set; }

        public virtual List<ShopModel> ShopModels { get; set; }
    }
}
