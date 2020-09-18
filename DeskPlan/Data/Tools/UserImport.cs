using CsvHelper;
using CsvHelper.Configuration;
using DeskPlan.Core.Context;
using DeskPlan.Core.Entities;
using DeskPlan.Core.Repositories;
using DeskPlan.Data.Services;
using ElectronNET.API;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPlan.Tools
{
    public class UserImport
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public UserImport(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ImportAsync(string file)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DeskPlanContext>();
                var uService = new UserService(new UserRepository(dbContext));

                using var reader = new StreamReader(file);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.HeaderValidated = null;

                var users = csv.GetRecordsAsync<User>();

                await foreach (var user in users)
                {
                    await uService.UpsertUserAsync(user);
                }
            }              
        }
    }
}
