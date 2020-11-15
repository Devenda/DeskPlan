using System.ComponentModel.DataAnnotations;

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

        public Room Room { get; set; }
    }
}
