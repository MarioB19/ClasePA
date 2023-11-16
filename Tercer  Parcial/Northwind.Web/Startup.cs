using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking; // CollectionEntry
using WorkingWithEFCore.AutoGens;

namespace NorthwindWeb
{
    public class Startup
    {
        //Este metodo es llamado por el runtime. Use este metodo para agregar servicios al contenedor, en este caso a nuestra base de datos
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            string databasePath = Path.Combine("..", "Northwind.db");
            services.AddDbContext<Northwind>(options => 
            options.UseSqlite($"Data Source = {databasePath}"));
        }
        //Este metodo es llamado por el runtime. Se usa este metodo para procesar las solicitud HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting(); // enrutamiento
            app.UseDefaultFiles(); // index.html, default.html, home.html
            app.UseStaticFiles(); // wwwroot

            //Definicion de Endpoints

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
             
            });
        }
    }
}
