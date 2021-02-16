using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int HorsePower { get; set; }
        public int Price { get; set; }
        public int MileAge { get; set; }
        public int MarkId { get; set; }
        public int TransmissionId { get; set; }
        public int CarcaseTypeId { get; set; }
        public int EngineTypeId { get; set; }
        public int DriveTypeId { get; set; }
    }
}
