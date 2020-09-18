using DeskPlan.Core.Context;
using DeskPlan.Core.Repositories;
using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Services;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Entities = DeskPlan.Core.Entities;

namespace DeskPlan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public UserService _userService;

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
            services.AddScoped<IUserRepository, UserRepository>();

            //Services
            services.AddScoped<UserService>();
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
                                        using var _dbContext = new DeskPlanContext();
                                        UserRepository ur = new UserRepository(_dbContext);
                                        
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
