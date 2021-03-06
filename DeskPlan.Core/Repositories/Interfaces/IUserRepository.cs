﻿using DeskPlan.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskPlan.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetByNumberAsync(string number);

        Task<List<User>> GetAllUsersAsync();

        Task<List<User>> GetAllEmployedUsersAsync();

        Task UpsertUserAsync(User user);

        Task InsertUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);
    }
}
