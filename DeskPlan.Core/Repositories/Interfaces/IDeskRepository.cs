using DeskPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories.Interfaces
{
    public interface IDeskRepository
    {
        Task<Desk> GetByIdAsync(int id);

        Task<List<Desk>> GetAllDesksAsync();

        Task<List<Desk>> GetAllDesksForRoomAsync(int roomId);

        Task InsertDeskAsync(Desk desk);

        Task UpdateDeskAsync(Desk desk);

        Task DeleteDeskAsync(Desk desk);
    }
}
