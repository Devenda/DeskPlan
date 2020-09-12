using System;
using System.Collections.Generic;

namespace DeskPlan.Core.Entities
{
    public partial class Desk
    {
        public Desk()
        {
            Planning = new HashSet<Planning>();
        }

        public long DeskId { get; set; }
        public string Name { get; set; }
        public long RoomId { get; set; }
        public long? LocationX { get; set; }
        public long? LocationY { get; set; }
        public byte[] Flex { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<Planning> Planning { get; set; }
    }
}
