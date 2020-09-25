﻿using DeskPlan.Core.Repositories.Interfaces;
using Entities = DeskPlan.Core.Entities;
using DeskPlan.Data.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DeskPlan.Data.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<Models.User?> GetByIdAsync(int id)
        {
            return (await _userRepository.GetByIdAsync(id)).ToModel();
        }

        public async Task<List<Models.User?>> GetAllUsers()
        {
            return (await _userRepository.GetAllUsersAsync()).Select(u => u.ToModel())
                                                             .ToList();
        }

        public async Task InsertUserAsync(Models.User user)
        {
            try
            {
                // TODO: check Number, use custom validator?
                await _userRepository.InsertUserAsync(user.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task UpdateUserAsync(Models.User user)
        {
            try
            {
                await _userRepository.UpdateUserAsync(user.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task DeleteUserAsync(Models.User user)
        {
            try
            {
                //TODO: Check for desks
                await _userRepository.DeleteUserAsync(user.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task UpsertUserAsync(Models.User user)
        {
            _logger.LogInformation("Call UpsertUserAsync");
            try
            {
                await _userRepository.UpsertUserAsync(user.ToEntity());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
