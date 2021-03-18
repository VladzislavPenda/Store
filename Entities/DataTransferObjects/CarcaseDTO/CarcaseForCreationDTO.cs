using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.CarcaseDTO
{
    public class CarcaseForCreationDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The name is too long (maximum 100 characters).")]
        public string type { get; set; }
    }
}
