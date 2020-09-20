using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Mapper;
using System;
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
    }
}
