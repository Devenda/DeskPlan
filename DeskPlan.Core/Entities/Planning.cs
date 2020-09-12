using System;
using System.Collections.Generic;

namespace DeskPlan.Core.Entities
{
    public partial class Planning
    {
        public long PlanningId { get; set; }
        public long Week { get; set; }
        public long Year { get; set; }
        public long? DeskId { get; set; }
        public long UserId { get; set; }

        public virtual Desk Desk { get; set; }
        public virtual User User { get; set; }
    }
}
