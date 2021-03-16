using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ModelForUpdatingDTO
    {
        public string model { get; set; }
        public int year { get; set; }
        public int horsePower { get; set; }
        public int price { get; set; }
        public int mileAge { get; set; }
    }
}
