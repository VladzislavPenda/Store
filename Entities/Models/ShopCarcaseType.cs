using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Serializable]
    [Table("CarcaseType")]
    public class ShopCarcaseType
    {
        [Column("carcaseTypeId")]
        public int id { get; set; }

        
        [StringLength(100, ErrorMessage = "The name is too long (maximum 100 characters).")]
        public string type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
