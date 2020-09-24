using DeskPlan.Core.Context;
using DeskPlan.Core.Entities;
using DeskPlan.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DeskPlanContext _dpContext;

        public RoomRepository(DeskPlanContext dpContext)
        {
            _dpContext = dpContext;
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _dpContext.Room.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            var r = await _dpContext.Room.FindAsync(id);
            _dpContext.Entry(r).State = EntityState.Detached;

            return r;
        }

        public async Task InsertRoomAsync(Room room)
        {
            await _dpContext.Room.AddAsync(room);

            await _dpContext.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _dpContext.Entry(room).State = EntityState.Modified;

            await _dpContext.SaveChangesAsync();
        }
        public async Task DeleteRoomAsync(Room room)
        {
            var r = await _dpContext.Room.FindAsync(room.RoomId);
            _dpContext.Room.Remove(r);

            await _dpContext.SaveChangesAsync();
        }
    }
}
