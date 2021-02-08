using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class ShopModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Не указано название модели.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Недопустимая длина названия модели.")]
        public string model { get; set; }

        [Range(1900, 2021, ErrorMessage = "Недопустимая дата выпуска авто.")]
        public int? year { get; set; }

        public int? horse_power { get; set; }

        [Required]
        public int price { get; set; }

        public int mileage { get; set; }

        public ShopCarcaseType ShopCarcaseType { get; set; }

        public ShopEngineType ShopEngineType { get; set; }

        public ShopTransmissionType ShopTransmissionType { get; set; }

        public ShopDriveType ShopDriveType { get; set; }

        public ShopMark ShopMark { get; set; }
    }
}
