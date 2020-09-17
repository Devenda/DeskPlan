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
            _dpContext.Set<User>().Attach(user);
            _dpContext.Entry(user).State = user.UserId == 0 ? EntityState.Added : EntityState.Modified;

            await _dpContext.SaveChangesAsync();

            //var u = await _dpContext.User.Where(u => u.UserId == user.UserId)
            //                             .FirstOrDefaultAsync();
            //if (u == null)
            //{
            //    await _dpContext.User.AddAsync(user);
            //}
            //else
            //{

            //}

            //await _dpContext.SaveChangesAsync();
        }
    }
}
