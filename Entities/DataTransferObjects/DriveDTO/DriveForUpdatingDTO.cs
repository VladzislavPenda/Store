using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.DriveDTO
{
    public class DriveForUpdatingDto
    {
        [StringLength(100, ErrorMessage = "The name is too long (maximum length 100 characters.")]
        public string type { get; set; }
        public IEnumerable<ModelForCreationDto> Models { get; set; }
    }
}
