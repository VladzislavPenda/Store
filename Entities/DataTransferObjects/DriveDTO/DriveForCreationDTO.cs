using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.DriveDTO
{
    public class DriveForCreationDto
    {
        [StringLength(100, ErrorMessage = "The name is too long (maximum length 100 characters.")]
        public string type { get; set; }
    }
}
