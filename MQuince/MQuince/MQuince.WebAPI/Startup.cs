using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQuince.Application;
using MQuince.Services.Contracts.Interfaces;
using VueCliMiddleware;

namespace MQuince.WebAPI
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
            services.AddDistributedMemoryCache();
            services.AddSession();
            
            App application = new App(Configuration);

            services.AddTransient(typeof(ICountryService), s => application.GetCountryService());
            services.AddTransient(typeof(ICityService), s => application.GetCityService());
            services.AddTransient(typeof(IPatientService), s => application.GetPatientService());
            services.AddTransient(typeof(IDoctorService), s => application.GetDoctorService());
            services.AddTransient(typeof(IAdressService), s => application.GetAdressService());
            services.AddTransient(typeof(IUserService), s => application.GetUserService());
            services.AddTransient(typeof(IFeedbackService), s => application.GetFeedbackService());

            services.AddControllers();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp"; });
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseCors(builder =>
                builder.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "clientapp";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });
        }
    }
}