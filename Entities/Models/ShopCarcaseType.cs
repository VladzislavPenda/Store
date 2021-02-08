using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ShopCarcaseType
    {
        public int id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Слишком длинное название(максимум 100 символов).")]
        public string type { get; set; }

        public virtual List<ShopModel> ShopModels { get; set; }
    }
}
