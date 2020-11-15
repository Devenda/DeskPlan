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
        public static Models.User ToModel(this Entities.User user)
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

        // Room
        public static Models.Room ToModel(this Entities.Room room)
        {
            return new Models.Room
            {
                RoomId = room.RoomId,
                Name = room.Name,
                MaxDesks = room.MaxDesks.ToString()
            };
        }

        // Desk
        public static Models.Desk ToModel(this Entities.Desk desk)
        {
            return new Models.Desk
            {
                DeskId = desk.DeskId,
                Name = desk.Name,
                Flex = desk.Flex,
                LocationX = desk.LocationX,
                LocationY = desk.LocationY,
                RoomId = desk.RoomId,
                Room = desk.Room.ToModel()
            };
        }

        // Planning
        public static Models.Planning ToModel(this Entities.Planning planning)
        {
            return new Models.Planning
            {
                PlanningId = planning.PlanningId,
                DeskId = planning.DeskId,
                Desk = planning.Desk.ToModel(),
                UserId = planning.UserId,
                User = planning.User.ToModel(),
                StartDate = planning.StartDate,
                EndDate = planning.EndDate
            };
        }
    }
}
