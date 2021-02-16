using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ShopCarcaseType
    {
        [Column("carcaseTypeId")]
        public int id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Слишком длинное название(максимум 100 символов).")]
        public string type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
