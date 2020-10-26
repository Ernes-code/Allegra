using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alegra.Data_Access.Implementation;
using Alegra.Data_Access.Interfaces;
using Alegra.Data_Design;
using Alegra.Logic.Handlers.Command;
using Alegra.Logic.Handlers.Query;
using Alegra.Logic.Interfaces;
using Alegra.Logic.Interfaces.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Alegra
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddDbContext<AlegraDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefualtConnection")));
            //Dependancy Ingection
            _ = services.AddSingleton<IDataTestRepository, DataTestRepository>();
            _ = services.AddSingleton<IUserExerciseRepository, UserExerciseRepository>();
            _ = services.AddSingleton<IUserExerciseCommandHandler, UserExersiseCommandHandler>();
            _ = services.AddSingleton<IUserExerciseQueryHandler, UserExerciseQueryHandler>();
            _ = services.AddControllers();
            _ = services.AddControllersWithViews();
            _ = services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            else
            {
                _ = app.UseExceptionHandler("/Home/Error");

                _ = app.UseHsts();
            }

            _ = app.UseSwagger();

            _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Allegra API Test"));

            _ = app.UseHttpsRedirection();

            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints => 
            {
               _ = endpoints.MapControllerRoute(
                     name: "default",
                    pattern: "{controller=Home}/{action=User}");
                _ = endpoints.MapControllers(); 
            });
        }
    }
}
