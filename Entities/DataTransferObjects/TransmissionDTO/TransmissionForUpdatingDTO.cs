using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TransmissionDTO
{
    public class TransmissionForUpdatingDTO
    {
        [StringLength(100, ErrorMessage = "Transmission type name is too long (maximum length 100 characters).")]
        public string type { get; set; }
        public IEnumerable<ModelForCreationDTO> Models { get; set; }
    }
}
