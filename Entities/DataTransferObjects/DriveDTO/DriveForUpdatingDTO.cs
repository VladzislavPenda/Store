using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.DriveDTO
{
    public class DriveForUpdatingDTO
    {
        [StringLength(100, ErrorMessage = "The name is too long (maximum length 100 characters.")]
        public string type { get; set; }
        public IEnumerable<ModelForCreationDTO> Models { get; set; }
    }
}
