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
                UserId = user.UserId,
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

        // Desk
        public static Entities.Desk ToEntity(this Models.Desk desk)
        {
            return new Entities.Desk
            {
                DeskId = desk.DeskId,
                Name = desk.Name,
                Flex = desk.Flex,
                LocationX = desk.LocationX,
                LocationY = desk.LocationY,
                RoomId = desk.RoomId
            };
        }

        // Planning
        public static Entities.Planning ToEntity(this Models.Planning planning)
        {
            return new Entities.Planning
            {
                PlanningId = planning.PlanningId,
                DeskId = planning.DeskId,
                UserId = planning.UserId,
                StartDate = planning.StartDate,
                EndDate = planning.EndDate
            };
        }
    }
}
