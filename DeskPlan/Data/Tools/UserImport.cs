using CsvHelper;
using DeskPlan.Core.Entities;
using ElectronNET.API;
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
        public async void Import(string file)
        {
            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.HeaderValidated = null;

                var records = csv.GetRecords<User>();
            }
        }
    }
}
