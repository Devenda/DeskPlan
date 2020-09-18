using DeskPlan.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();

        Task UpsertUserAsync(User user);

        void UpsertUser(User user);
    }
}
