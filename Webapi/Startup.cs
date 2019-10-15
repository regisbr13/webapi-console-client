using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Webapi.Business;
using Webapi.Data;
using Webapi.Interfaces.Business;
using Webapi.Models;
using Webapi.Repository;
using Webapi.Repository.Interfaces;

namespace Webapi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();		
            services.AddSession();				
		    services.AddSession(options => {options.IdleTimeout = TimeSpan.FromDays(1);});


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IComputerRepository, ComputerRepository>();

            services.AddScoped<IBusiness<Computer>, ComputerBusiness>();
            services.AddScoped<LoginBusiness>();
            services.AddScoped<SchedulingBusiness>();

            services.AddSwaggerGen(x => {
		        x.SwaggerDoc("v1", new Info {Title = "Access WebApi", Version = "v1"});
	        });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options => {options.LoginPath = "/users/Login";});	
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            	app.UseSwagger(c => 
                {
                    c.RouteTemplate = "swagger/{documentName}/swagger.json";
                });
                
                app.UseSwaggerUI(x => {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");	
                });
                var option = new RewriteOptions();
                option.AddRedirect("^$", "swagger");					
                app.UseRewriter(option);

            app.UseAuthentication();
            app.UseSession(); 
            app.UseMvc();
        }
    }
}
