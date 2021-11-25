using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Storages
{
    public class StorageDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public int NumberOfCars { get; set; }
    }
}
