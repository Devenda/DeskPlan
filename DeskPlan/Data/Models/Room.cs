using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Models
{
    public class Room
    {
        public string Name { get; set; } = null!;

        public int MaxDesks { get; set; }

        public List<Desk?> Desks { get; set; } = null!;
    }
}
