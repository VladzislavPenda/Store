using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Profession
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage ="Salary can't be less than zero")]
        public int Salary { get; set; }
        public ICollection<Employee> Employees { get; set; } 
    }
}
