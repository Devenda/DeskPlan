using DeskPlan.Core.Context;
using DeskPlan.Core.Entities;
using DeskPlan.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DeskPlanContext _dpContext;

        public UserRepository(DeskPlanContext dpContext)
        {
            _dpContext = dpContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dpContext.User.ToListAsync();
        }

        public async Task UpsertUserAsync(User user)
        {
            await _dpContext.User.Upsert(user)
                                 .On(u => u.Number)
                                 .RunAsync();
        }
    }
}
