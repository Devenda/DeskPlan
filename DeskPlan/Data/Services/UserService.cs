using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Mapper;
using DeskPlan.Data.Model;
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

        public async Task<List<User>> GetAllUsers()
        {
            return (await _userRepository.GetAllUsers()).Select(u => u.ToModel())
                                                        .ToList();
        }
    }
}
