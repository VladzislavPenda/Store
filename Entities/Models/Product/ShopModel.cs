using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Serializable]
    public class ShopModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, specify model name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Model name is to long. Max length is 100 symbols")]
        public string Model { get; set; }

        [Range(1900, 2021, ErrorMessage = "Incorrect year of car production. Your car should be created after 1900 and before 2021")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please, indicate horsepower.")]
        public int? HorsePower { get; set; }

        [Required(ErrorMessage ="Please, indicate price.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please, specify the mileage.")]
        public int MileAge { get; set; }

        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage ="Number of cars can't be less than zero")]
        public int NumberOfCar { get; set; }

        [ForeignKey(nameof(ShopMark))]
        public int MarkId { get; set; }

        public ShopMark ShopMark { get; set; }

        [ForeignKey(nameof(ShopTransmissionType))]
        public int TransmissionTypeId { get; set; }
        public ShopTransmissionType ShopTransmissionType { get; set; }

        [ForeignKey(nameof(ShopCarcaseType))]
        public int CarcaseTypeId { get; set; }
        public ShopCarcaseType ShopCarcaseType { get; set; }

        [ForeignKey(nameof(ShopEngineType))]
        public int EngineTypeId { get; set; }
        public ShopEngineType ShopEngineType { get; set; }

        [ForeignKey(nameof(ShopDriveType))]
        public int DriveTypeId { get; set; }
        public ShopDriveType ShopDriveType { get; set; }
        [ForeignKey(nameof(CarShop))]
        public Guid CarShopId { get; set; }
        public CarShop CarShop { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }

    partial class EntityTypeConfiguration: IEntityTypeConfiguration<ShopModel>
    {
        public void Configure(EntityTypeBuilder<ShopModel> e)
        {
            e.Property(c => c.Id).HasColumnName("model_id");
            e.Property(c => c.MileAge).HasColumnName("mile_age");
            e.Property(c => c.HorsePower).HasColumnName("horse_power");
            e.Property(c => c.MarkId).HasColumnName("mark_id");
            e.Property(c => c.Model).HasColumnName("model");
            e.Property(c => c.NumberOfCar).HasColumnName("number_of_car");
        }
    }
}
