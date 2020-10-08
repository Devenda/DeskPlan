using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeskPlan.Core.Entities
{
    public partial class Planning
    {
        [Key]
        public int PlanningId { get; set; }

        public int DeskId { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }


        public Desk Desk { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
