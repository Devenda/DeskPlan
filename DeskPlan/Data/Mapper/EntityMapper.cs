using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities = DeskPlan.Core.Entities;

namespace DeskPlan.Data.Mapper
{
    public static class EntityMapper
    {
        // User
        public static Entities.User ToEntity(this Models.User user)
        {
            return new Entities.User
            {
                Number = user.Number,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                StartDate = user.StartDate,
                EndDate = user.EndDate
            };
        }

        // Room
        public static Entities.Room ToEntity(this Models.Room room)
        {
            return new Entities.Room
            {
                RoomId = room.RoomId,
                Name = room.Name,
                MaxDesks = int.Parse(room.MaxDesks)
            };
        }
    }
}
