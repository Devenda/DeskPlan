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
                    MaxDesks = room.MaxDesks.ToString()
                };
            }

            return null;
        }

        // Desk
        public static Models.Desk? ToModel(this Entities.Desk desk)
        {
            if (desk != null)
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

            return null;
        }

        // Planning
        public static Models.Planning? ToModel(this Entities.Planning planning)
        {
            if (planning != null)
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

            return null;
        }
    }
}
