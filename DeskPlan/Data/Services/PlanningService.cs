using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Mapper;
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

        public async Task<List<Models.Planning?>> GetAllPlanningsAsync()
        {
            var planning = (await _planningRepository.GetAllPlanningsAsync()).Select(r => r.ToModel())
                                                             .ToList();

            // Is plan has no end just set is a week past the last end time
            var maxEnd = planning.Max(p => p.EndDate);

            foreach (var plan in planning)
            {
                if (plan.EndDate == null)
                    plan.EndDate = maxEnd?.AddDays(7);
            }

            return planning;
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
                //TODO: Check for plannings
                await _planningRepository.DeletePlanningAsync(planning.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
