using System;
using System.Collections.Generic;

namespace DeskPlan.Core.Entities
{
    public partial class Room
    {
        public Room()
        {
            Desk = new HashSet<Desk>();
        }

        public long RoomId { get; set; }
        public string Name { get; set; }
        public long Desks { get; set; }

        public virtual ICollection<Desk> Desk { get; set; }
    }
}
