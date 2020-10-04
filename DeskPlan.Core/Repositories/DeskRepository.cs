using DeskPlan.Core.Context;
using DeskPlan.Core.Entities;
using DeskPlan.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories
{
    public class DeskRepository : IDeskRepository
    {
        private readonly DeskPlanContext _dpContext;

        public DeskRepository(DeskPlanContext dpContext)
        {
            _dpContext = dpContext;
        }

        public async Task<List<Desk>> GetAllDesksAsync()
        {
            return await _dpContext.Desk.Include(d => d.Room)
                                        .ToListAsync();
        }

        public async Task<List<Desk>> GetAllDesksForRoomAsync(int roomId)
        {
            return await _dpContext.Desk.Where(d => d.RoomId == roomId)
                                        .ToListAsync();
        }

        public async Task<Desk> GetByIdAsync(int id)
        {
            var r = await _dpContext.Desk.FindAsync(id);
            _dpContext.Entry(r).State = EntityState.Detached;

            return r;
        }

        public async Task InsertDeskAsync(Desk desk)
        {
            await _dpContext.Desk.AddAsync(desk);

            await _dpContext.SaveChangesAsync();
        }

        public async Task UpdateDeskAsync(Desk desk)
        {
            _dpContext.Entry(desk).State = EntityState.Modified;

            await _dpContext.SaveChangesAsync();
        }
        public async Task DeleteDeskAsync(Desk desk)
        {
            var r = await _dpContext.Desk.FindAsync(desk.DeskId);
            _dpContext.Desk.Remove(r);

            await _dpContext.SaveChangesAsync();
        }
    }
}
