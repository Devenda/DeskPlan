using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Services
{
    public class PlanningService
    {
        private readonly IPlanningRepository _planningRepository;

        public PlanningService(IPlanningRepository planningRepository)
        {
            _planningRepository = planningRepository;
        }

        public async Task<Models.Planning?> GetByIdAsync(int id)
        {
            return (await _planningRepository.GetByIdAsync(id)).ToModel();
        }

        public async Task<List<Models.Planning>> GetAllPlanningsAsync()
        {
            var planning = (await _planningRepository.GetAllPlanningsAsync()).ConvertAll(r => r.ToModel())
;
            return SetEndDates(planning);
        }

        public async Task<List<Models.Planning>> GetAllActivePlanningsForDeskAsync(int deskId)
        {
            var planning = (await _planningRepository.GetAllActivePlanningsForDeskAsync(deskId)).ConvertAll(r => r.ToModel())
;
            return SetEndDates(planning);
        }

        public async Task<List<Models.Planning>> GetPlanningsActiveBetweenAsync(DateTime startDate, DateTime endDate)
        {
            var planning = (await _planningRepository.GetPlanningsActiveBetweenAsync(startDate, endDate)).ConvertAll(r => r.ToModel())
;
            return SetEndDates(planning);
        }

        private List<Models.Planning> SetEndDates(List<Models.Planning> plannings)
        {
            // If plan has no end just set it a week past the last end time
            var maxEnd = plannings.Max(p => p.EndDate);

            foreach (var plan in plannings)
            {
                if (plan.EndDate == null)
                    plan.EndDate = (maxEnd ?? DateTime.Now).AddDays(7);
            }

            return plannings;
        }

        public async Task InsertPlanningAsync(Models.Planning planning)
        {
            try
            {
                await _planningRepository.InsertPlanningAsync(planning.ToEntity());
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task UpdatePlanningAsync(Models.Planning planning)
        {
            try
            {
                await _planningRepository.UpdatePlanningAsync(planning.ToEntity());
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task DeletePlanningAsync(Models.Planning planning)
        {
            try
            {
                await _planningRepository.DeletePlanningAsync(planning.ToEntity());
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Models.Planning> IsOccupiedBy(int deskId, DateTime startDate, DateTime? endDate)
        {
            try
            {
                return (await _planningRepository.IsOccupiedBy(deskId, startDate, endDate)).ToModel();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
