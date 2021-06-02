﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Serializable]
    public class ShopModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please, specify model name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Model name is to long. Max length is 100 symbols")]
        public string model { get; set; }

        [Range(1900, 2021, ErrorMessage = "Incorrect year of car production. Your car should be created after 1900 and before 2021")]
        public int? year { get; set; }
        [Required(ErrorMessage = "Please, indicate horsepower.")]
        public int? horsePower { get; set; }

        [Required(ErrorMessage ="Please, indicate price.")]
        public int price { get; set; }
        [Required(ErrorMessage = "Please, specify the mileage.")]
        public int mileAge { get; set; }

        public string description { get; set; }

        
        public string pathToPicture { get; set; }
        [Required]
        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Please enter valid phone no.")]
        [StringLength(13, MinimumLength = 13)]
        public string phoneNumber { get; set; }

        [ForeignKey(nameof(ShopMark))]
        public int markId { get; set; }

        public ShopMark ShopMark { get; set; }

        [ForeignKey(nameof(ShopTransmissionType))]
        public int transmissionId { get; set; }
        public ShopTransmissionType ShopTransmissionType { get; set; }

        [ForeignKey(nameof(ShopCarcaseType))]
        public int carcaseTypeId { get; set; }
        public CarcaseType ShopCarcaseType { get; set; }

        [ForeignKey(nameof(ShopEngineType))]
        public int engineTypeId { get; set; }
        public ShopEngineType ShopEngineType { get; set; }

        [ForeignKey(nameof(ShopDriveType))]
        public int driveTypeId { get; set; }
        public ShopDriveType ShopDriveType { get; set; }        
    }
}
