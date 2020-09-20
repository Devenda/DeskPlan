using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Models
{
    public class Desk
    {
        public string Name { get; set; } = null!;

        public int? LocationX { get; set; }

        public int? LocationY { get; set; }

        public bool Flex { get; set; }

        public Room Room { get; set; } = null!;
    }
}
