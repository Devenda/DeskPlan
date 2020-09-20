using DeskPlan.Core.Context;
using DeskPlan.Core.Entities;
using DeskPlan.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //await _dpContext.User.Upsert(user)
            //                     .On(u => u.Number)
            //                     .RunAsync();

            //await _dpContext.Entry(user).ReloadAsync();

            var u = await _dpContext.User.Where(u => u.Number == user.Number)
                                         .FirstOrDefaultAsync();

            if (u == null)
            {
                await _dpContext.AddAsync(user);
            }
            else
            {
                u.Number = user.Number;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.EmailAddress = user.EmailAddress;
                u.StartDate = user.StartDate;
                u.EndDate = user.EndDate;
            }

            await _dpContext.SaveChangesAsync();
        }
    }
}
