using DeskPlan.Core.Context;
using DeskPlan.Core.Entities;
using DeskPlan.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<User> GetByIdAsync(int id)
        {
            var r = await _dpContext.User.FindAsync(id);
            _dpContext.Entry(r).State = EntityState.Detached;

            return r;
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

        public async Task InsertUserAsync(User user)
        {
            await _dpContext.User.AddAsync(user);

            await _dpContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dpContext.Entry(user).State = EntityState.Modified;

            await _dpContext.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(User user)
        {
            var r = await _dpContext.User.FindAsync(user.UserId);
            _dpContext.User.Remove(r);

            await _dpContext.SaveChangesAsync();
        }
    }
}
