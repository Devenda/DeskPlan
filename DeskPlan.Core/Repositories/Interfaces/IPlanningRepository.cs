using DeskPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories.Interfaces
{
    public interface IPlanningRepository
    {
        Task<Planning> GetByIdAsync(int id);

        Task<List<Planning>> GetAllPlanningsAsync();

        Task<List<Planning>> GetAllActivePlanningsForDeskAsync(int deskId);

        Task<List<Planning>> GetPlanningsActiveBetweenAsync(DateTime startDate, DateTime endDate);

        Task<Planning> IsOccupiedBy(int deskId, DateTime startDate, DateTime? endDate);

        Task InsertPlanningAsync(Planning planning);

        Task UpdatePlanningAsync(Planning planning);

        Task DeletePlanningAsync(Planning planning);
    }
}
