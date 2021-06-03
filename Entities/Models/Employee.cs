using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey(nameof(CarShop))]
        public Guid CarShopId { get; set; }
        [ForeignKey(nameof(Profession))]
        public Guid ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public string ContactPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
