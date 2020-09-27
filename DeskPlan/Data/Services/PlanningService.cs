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
            return (await _planningRepository.GetAllPlanningsAsync()).Select(r => r.ToModel())
                                                             .ToList();
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
