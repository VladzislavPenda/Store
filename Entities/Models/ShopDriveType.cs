using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ShopDriveType
    {
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "Слишком длинное название(максимальная длина 100 символов.")]
        public string type { get; set; }

        public virtual List<ShopModel> ShopModels { get; set; }
    }
}
