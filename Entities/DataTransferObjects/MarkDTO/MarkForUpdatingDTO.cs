using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.MarkDTO
{
    public class MarkForUpdatingDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The name of the car brand is too long (maximum length 100 characters).")]
        public string markNum { get; set; }

        [StringLength(100, ErrorMessage = "Manufacturer country name too long (maximum length 100 characters).")]
        public string country { get; set; }

        public IEnumerable<ModelForCreationDTO> Models { get; set; }
    }
}
