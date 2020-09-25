using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 100)]
        public string MaxDesks { get; set; } = null!;

        public List<Desk?> Desks { get; set; } = null!;
    }
}
