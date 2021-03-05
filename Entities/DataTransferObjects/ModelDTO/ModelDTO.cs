using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ModelDTO
    {
        public int id { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int horsePower { get; set; }
        public int price { get; set; }
        public int mileAge { get; set; }
        public int markId { get; set; }
        public int transmissionId { get; set; }
        public int carcaseTypeId { get; set; }
        public int engineTypeId { get; set; }
        public int driveTypeId { get; set; }
    }
}
