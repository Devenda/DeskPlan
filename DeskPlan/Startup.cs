using DeskPlan.Core.Context;
using DeskPlan.Core.Repositories;
using DeskPlan.Core.Repositories.Interfaces;
using DeskPlan.Data.Services;
using DeskPlan.Tools;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            //DB Context
            services.AddDbContext<DeskPlanContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DeskPlanDatabase"))
                       .EnableSensitiveDataLogging(), ServiceLifetime.Transient);

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IDeskRepository, DeskRepository>();
            services.AddScoped<IPlanningRepository, PlanningRepository>();

            //Services
            services.AddScoped<UserService>();
            services.AddScoped<RoomService>();
            services.AddScoped<DeskService>();
            services.AddScoped<PlanningService>();

            //Called from menu (no scope)
            services.AddScoped<UserImport>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserImport userImport)
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
                //new MenuItem {
                //    Label = "File",
                //    Type=MenuType.submenu,
                //    Submenu = new MenuItem[]
                //    {
                //        new MenuItem
                //        {
                //            Label = "Import Users", Type=MenuType.normal, Click = async () =>
                //                {
                //                    var mainWindow = Electron.WindowManager.BrowserWindows.First();
                //                    var options = new OpenDialogOptions
                //                    {
                //                        DefaultPath= "C:/",
                //                        Properties = new OpenDialogProperty[] {OpenDialogProperty.openFile}
                //                    };

                //                    var files = await Electron.Dialog.ShowOpenDialogAsync(mainWindow,options);

                //                    if (files.Length >= 1){
                //                        //await _userImport.ImportAsync(files[0]);
                //                    }
                //                }
                //            }
                //        }
                //},
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
