using DeskPlan.Core.Repositories.Interfaces;
using Entities = DeskPlan.Core.Entities;
using DeskPlan.Data.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Data.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Model.User>> GetAllUsers()
        {
            return (await _userRepository.GetAllUsersAsync()).Select(u => u.ToModel())
                                                             .ToList();
        }

        public async Task UpsertUser(Entities.User user)
        {
            try
            {
                await _userRepository.UpsertUserAsync(user);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
