using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Model
{
    public class User
    {
        public long UserId { get; set; }
        public long Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
