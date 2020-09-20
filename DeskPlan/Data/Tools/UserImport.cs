using CsvHelper;
using CsvHelper.Configuration;
using DeskPlan.Core.Context;
using DeskPlan.Core.Repositories;
using Models = DeskPlan.Data.Models;
using DeskPlan.Data.Services;
using ElectronNET.API;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        private readonly UserService _userService;

        public UserImport(UserService userService)
        {
            _userService = userService;
        }

        public async Task ImportAsync(string file)
        {
            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.MissingFieldFound = null;
            csv.Configuration.HeaderValidated = null;

            var users = csv.GetRecordsAsync<Models.User>();

            await foreach (var user in users)
            {
                await _userService.UpsertUserAsync(user);
            }
        }
    }
}
