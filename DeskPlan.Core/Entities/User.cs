using System;
using System.Collections.Generic;

namespace DeskPlan.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Planning = new HashSet<Planning>();
        }

        public long UserId { get; set; }
        public long Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] StartDate { get; set; }
        public byte[] EndDate { get; set; }

        public virtual ICollection<Planning> Planning { get; set; }
    }
}
