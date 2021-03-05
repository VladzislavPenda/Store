using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int? horsePower { get; set; }

        [Required]
        public int price { get; set; }

        public int mileAge { get; set; }

        [ForeignKey(nameof(ShopMark))]
        public int markId { get; set; }

        [ForeignKey(nameof(ShopTransmissionType))]
        public int transmissionId { get; set; }

        [ForeignKey(nameof(ShopCarcaseType))]
        public int carcaseTypeId { get; set; }

        [ForeignKey(nameof(ShopEngineType))]
        public int engineTypeId { get; set; }

        [ForeignKey(nameof(ShopDriveType))]
        public int driveTypeId { get; set; }
        public ShopCarcaseType ShopCarcaseType { get; set; }

        public ShopEngineType ShopEngineType { get; set; }

        public ShopTransmissionType ShopTransmissionType { get; set; }

        public ShopDriveType ShopDriveType { get; set; }

        public ShopMark ShopMark { get; set; }
    }
}
