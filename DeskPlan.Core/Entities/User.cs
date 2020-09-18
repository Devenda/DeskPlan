using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeskPlan.Core.Entities
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }

        public string Number { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public List<Planning> Plannings { get; set; }
    }
}
