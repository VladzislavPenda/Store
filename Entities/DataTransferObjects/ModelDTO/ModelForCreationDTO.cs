using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    // update
    public class ModelForCreationDto
    {
        [Required(ErrorMessage = "Please, specify model name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Model name is to long. Max length is 100 symbols")]
        public string model { get; set; }

        [Range(1900, 2021, ErrorMessage = "Incorrect year of car production. Your car should be created after 1900 and before 2021")]
        public int year { get; set; }

        [Required(ErrorMessage = "Please, indicate horsepower.")]
        [Range(1, int.MaxValue, ErrorMessage ="Please, indicate horsepower correct.")]
        public int horsePower { get; set; }

        [Required(ErrorMessage = "Please, indicate price.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please, indicate price correct.")]
        public int price { get; set; }

        [Required(ErrorMessage = "Please, specify the mileage.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please, indicate mileage correct.")]
        public int mileAge { get; set; }
        public string description { get; set; }
        public List<string> Characteristics { get; set; }
        //public string CarcaseType { get; set; }
        //public string EngineType { get; set; }
        //public string DriveType { get; set; }
        //public string TransmissionType { get; set; }
        //public string Mark { get; set; }

        //public IEnumerable<MarkForCreationDto> marks { get; set; }
    }
}
