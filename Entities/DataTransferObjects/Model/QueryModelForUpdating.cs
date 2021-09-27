using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class QueryModelForUpdating
    {
        public string Model { get; set; }

        [Range(1900, 2021, ErrorMessage = "Incorrect year of car production. Your car should be created after 1900 and before 2021")]
        public int Year { get; set; }

        public int HorsePower { get; set; }

        public int Price { get; set; }

        public int MileAge { get; set; }
  
        public int NumberOfCar { get; set; }
 
        public string Description { get; set; }
      
        public string StorageAddress { get; set; }
        public string[] EntsToAdd { get; set; }
        public string[] EntsToRemove { get; set; }

    }
}
