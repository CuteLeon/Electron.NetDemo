using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Electron.NetDemo.CoreMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            Task.Run(async () => await ElectronNET.API.Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions()
            {
                AlwaysOnTop = false,
                AutoHideMenuBar = true,
                AcceptFirstMouse = false,
                BackgroundColor = "#F00",
                Center = true,
                Closable = false,
                DarkTheme = false,
                DisableAutoHideCursor = false,
                EnableLargerThanScreen = false,
                Focusable = true,
                Fullscreen = true,
                Fullscreenable = true,
                FullscreenWindowTitle = false,
                HasShadow = true,
                Icon = null,
                Kiosk = true,
                Maximizable = true,
                Minimizable = true,
                Modal = false,
                Movable = true,
                Resizable = true,
                SkipTaskbar = false,
                TabbingIdentifier = "CustomeTabbingIdentifier",
                Show = true,
                ThickFrame = true,
                Title = "ElectronNET ÑÝÊ¾ÏîÄ¿",
                TitleBarStyle = TitleBarStyle.defaultStyle,
                Transparent = true,
                UseContentSize = false,
                Vibrancy = Vibrancy.dark,
                WebPreferences = new WebPreferences()
                {
                    DevTools = true,
                }
            }));
        }
    }
}
