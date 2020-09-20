using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeskPlan.Core.Entities
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        public string Name { get; set; } = null!;

        public int MaxDesks { get; set; }

        public List<Desk>? Desks { get; set; }
    }
}
