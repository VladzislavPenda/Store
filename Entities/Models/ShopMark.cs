using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ShopMark
    {
        [Column("MarkId")]
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название марки авто(максимальная длина 100 символов).")]
        public string markNum { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название страны производителя(максимальная длина 100 символов).")]
        public string country { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
