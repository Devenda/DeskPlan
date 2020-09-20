using DeskPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoomsAsync();

        Task InsertRoomAsync(Room room);
    }
}
