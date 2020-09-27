using System;
using System.ComponentModel.DataAnnotations;

namespace DeskPlan.Data.Models
{
    public class Planning
    {
        public int PlanningId { get; set; }

        [Required]
        public int DeskId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }


        public Desk Desk { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
