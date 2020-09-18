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
                    StartDate = user.StartDate,
                    EndDate = user.EndDate
                };
            }

            return null;
        }
    }
}
