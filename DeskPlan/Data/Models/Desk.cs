using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Models
{
    public class Desk
    {
        public int DeskId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int? LocationX { get; set; }

        public int? LocationY { get; set; }

        public bool Flex { get; set; }

        [Required]
        public int RoomId { get; set; }

        public Room Room { get; set; } = null!;
    }
}
