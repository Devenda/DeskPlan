using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DeskPlan.Data;
using ElectronNET.API;
using DeskPlan.Core.Context;
using Microsoft.EntityFrameworkCore;
using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Core.Repositories;
using DeskPlan.Data.Services;
using ElectronNET.API.Entities;
using DeskPlan.Tools;

namespace DeskPlan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public UserService _userService { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            //DB Context
            services.AddDbContext<DeskPlanContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DeskPlanDatabase")));

            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            //Services
            services.AddTransient<UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserService userService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            // Open the Electron-Window here
            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());

            // Config menu
            _userService = userService;
            StartElectron();
        }

        private void StartElectron()
        {
            var menu = new MenuItem[] {
                new MenuItem {
                    Label = "File",
                    Type=MenuType.submenu,
                    Submenu = new MenuItem[]
                    {
                        new MenuItem
                        {
                            Label = "Import Users", Type=MenuType.normal, Click = async () =>
                                {
                                    var mainWindow = Electron.WindowManager.BrowserWindows.First();
                                    var options = new OpenDialogOptions
                                    {
                                        DefaultPath= "C:/",
                                        Properties = new OpenDialogProperty[] {OpenDialogProperty.openFile}
                                    };

                                    var files = await Electron.Dialog.ShowOpenDialogAsync(mainWindow,options);

                                    if (files.Length >= 1){
                                        //UserImport import = new UserImport(_userService);
                                        //await import.Import(files[0]);
                                        await _userService.UpsertUser(new Core.Entities.User
                                        {
                                            UserId = 1,
                                            FirstName ="Tinus",
                                            LastName = "Scheppers",
                                            StartDate = "2020-07-01"
                                        });
                                    }
                                }
                            }
                        }
                },
                new MenuItem {
                    Label = "View",
                    Type = MenuType.submenu,
                    Submenu = new MenuItem[] {
                        new MenuItem {
                            Label = "Open Developer Tools",
                            Accelerator = "CmdOrCtrl+I",
                            Click = () => Electron.WindowManager.BrowserWindows.First().WebContents.OpenDevTools()
                        }
                    }
                }
            };

            Electron.Menu.SetApplicationMenu(menu);
        }
    }
}
