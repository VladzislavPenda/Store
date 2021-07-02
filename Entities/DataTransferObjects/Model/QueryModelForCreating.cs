using Entities.DataTransferObjects.EntDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.QueryModelDto
{
    public class QueryModelForCreating
    {
        
        [Required(ErrorMessage = "Please, specify model name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Model name is to long. Max length is 100 symbols")]
        public string Model { get; set; }

        [Range(1900, 2021, ErrorMessage = "Incorrect year of car production. Your car should be created after 1900 and before 2021")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please, indicate horsepower.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please, indicate horsepower correct.")]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = "Please, indicate price.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please, indicate price correct.")]
        public int Price { get; set; }

        //[Required(ErrorMessage = "Please, specify the mileage.")]
        //[Range(1, int.MaxValue, ErrorMessage = "Please, indicate mileage correct.")]
        ////public int MileAge { get; set; }
        public string Description { get; set; }
        public int NumberOfCar { get; set; }
        public string StorageAddress { get; set; }
        public bool IsActive { get; set; }
        public string[] EntsString { get; set; }
        public string[] Pictures { get; set; }
        public EntCreateDto[] Ents { get; set; }
    }
}
