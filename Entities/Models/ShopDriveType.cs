﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Serializable]
    [Table("DriveType")]
    public class ShopDriveType
    {
        [Column("driveTypeId")]
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "The name is too long (maximum length 100 characters.")]
        public string type { get; set; }

        public ICollection<ShopModel> ShopModels { get; set; }
    }
}
