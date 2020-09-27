using DeskPlan.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories.Interfaces
{
    public interface IPlanningRepository
    {
        Task<Planning> GetByIdAsync(int id);

        Task<List<Planning>> GetAllPlanningsAsync();

        Task InsertPlanningAsync(Planning planning);

        Task UpdatePlanningAsync(Planning planning);

        Task DeletePlanningAsync(Planning planning);
    }
}
