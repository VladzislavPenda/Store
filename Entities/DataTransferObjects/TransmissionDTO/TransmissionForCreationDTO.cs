using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TransmissionDTO
{
    public class TransmissionForCreationDTO
    {
        [StringLength(100, ErrorMessage = "Transmission type name is too long (maximum length 100 characters).")]
        public string type { get; set; }
    }
}
