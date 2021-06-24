using System;

namespace Entities.DataTransferObjects.IncludeDTO
{
    public class ModelFullInfo
    {
        public string carcaseType { get; set; } 
        public string driveType { get; set; }
        public string engineType { get; set; }
        public int? year { get; set; }
        public int? horsePower { get; set; }
        public string markName { get; set; }
        public int mileAge { get; set; }
        public string model { get; set; }
        public string description { get; set; }
        public Guid modelId { get; set; }
        public int price { get; set; }
        public string transmission { get; set; }
    }
}
