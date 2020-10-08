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
        
        private DateTime startDate;
        [Required]
        public DateTime StartDate
        {
            get { return startDate.Date; }
            set { startDate = value.Date; }
        }

        private DateTime? endDate;
        public DateTime? EndDate
        {
            get { return endDate?.Date; }
            set { endDate = value?.Date; }
        }

        public Desk Desk { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
