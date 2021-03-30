using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.EngineDTO
{
    public class EngineForUpdatingDto
    {
        [StringLength(100, ErrorMessage = "The name for the engine type is too long (maximum length 100 characters).")]
        public string type { get; set; }
        public IEnumerable<ModelForCreationDto> Models { get; set; }
    }
}
