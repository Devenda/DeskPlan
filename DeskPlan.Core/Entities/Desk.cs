using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeskPlan.Core.Entities
{
    public partial class Desk
    {
        [Key]
        public int DeskId { get; set; }

        public string Name { get; set; }

        public int RoomId { get; set; }

        public int? LocationX { get; set; }

        public int? LocationY { get; set; }

        public bool Flex { get; set; }


        public Room Room { get; set; }

        public List<Planning> Plannings { get; set; }


}
}
