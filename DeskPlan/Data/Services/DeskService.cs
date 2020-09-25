using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Services
{
    public class DeskService
    {
        private readonly IDeskRepository _deskRepository;

        public DeskService(IDeskRepository deskRepository)
        {
            _deskRepository = deskRepository;
        }

        public async Task<Models.Desk?> GetByIdAsync(int id)
        {
            return (await _deskRepository.GetByIdAsync(id)).ToModel();
        }

        public async Task<List<Models.Desk?>> GetAllDesksAsync()
        {
            return (await _deskRepository.GetAllDesksAsync()).Select(r => r.ToModel())
                                                             .ToList();
        }

        public async Task InsertDeskAsync(Models.Desk desk)
        {
            try
            {
                await _deskRepository.InsertDeskAsync(desk.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task UpdateDeskAsync(Models.Desk desk)
        {
            try
            {
                await _deskRepository.UpdateDeskAsync(desk.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task DeleteDeskAsync(Models.Desk desk)
        {
            try
            {
                //TODO: Check for desks
                await _deskRepository.DeleteDeskAsync(desk.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
