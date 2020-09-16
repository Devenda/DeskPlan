using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Mapper
{
    public static class ModelMapper
    {
        public static Model.User ToModel(this Core.Entities.User user)
        {
            if (user != null)
            {
                return new Model.User
                {
                    UserId = user.UserId,
                    Number = user.Number,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress,
                    StartDate = string.IsNullOrEmpty(user.StartDate) ? (DateTime?)null : DateTime.Parse(user.StartDate, null, DateTimeStyles.RoundtripKind),
                    EndDate = string.IsNullOrEmpty(user.EndDate) ? (DateTime?)null : DateTime.Parse(user.EndDate, null, DateTimeStyles.RoundtripKind)
                };
            }

            return null;
        }
    }
}
