using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Number { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
