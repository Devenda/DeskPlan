using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Models.Room?> GetByIdAsync(int id)
        {
            return (await _roomRepository.GetByIdAsync(id)).ToModel();
        }

        public async Task<List<Models.Room?>> GetAllRooms()
        {
            return (await _roomRepository.GetAllRoomsAsync()).Select(r => r.ToModel())                                                             
                                                             .ToList();
        }

        public async Task InsertRoomAsync(Models.Room room)
        {
            try
            {
                await _roomRepository.InsertRoomAsync(room.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task UpdateRoomAsync(Models.Room room)
        {
            try
            {
                await _roomRepository.UpdateRoomAsync(room.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task DeleteRoomAsync(Models.Room room)
        {
            try
            {
                //TODO: Check for desks
                await _roomRepository.DeleteRoomAsync(room.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
