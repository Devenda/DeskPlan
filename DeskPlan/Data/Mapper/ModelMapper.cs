using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Entities = DeskPlan.Core.Entities;

namespace DeskPlan.Data.Mapper
{
    public static class ModelMapper
    {
        // User
        public static Models.User? ToModel(this Entities.User user)
        {
            if (user != null)
            {
                return new Models.User
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

        // Room
        public static Models.Room? ToModel(this Entities.Room room)
        {
            if (room != null)
            {
                return new Models.Room
                {
                    RoomId = room.RoomId,
                    Name = room.Name,
                    MaxDesks = room.MaxDesks
                };
            }

            return null;
        }
    }
}
