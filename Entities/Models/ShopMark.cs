using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class ShopMark
    {
        [Column("markId")]
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "The name of the car brand is too long (maximum length 100 characters).")]
        public string markNum { get; set; }

        [StringLength(100, ErrorMessage = "Manufacturer country name too long (maximum length 100 characters).")]
        public string country { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
