using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCDC_API.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace GCDC_API
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
            //Wire CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                      builder =>
                      {
                          builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
            });

            //Wire EntityFramework
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<SqlDbContext>(options =>
            {
                options.UseSqlServer(connectionString, o =>
                {
                    o.UseRowNumberForPaging(); //Backwards compatibility for for SQL 2008 R2
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "GCDC API",
                    Version = "v1.0.0",
                    Description = "This API gives you access to all <b>GCDC <i>(Global Change Data Centre)</i></b> data. <br/>" +
                    "Read access is unauthenticated, but some write actions might require authentication <i>(look out for the lock icon)</i>",
                    //Contact = new Contact() { Name = "Contact Us", Url = "http://app01.saeon.ac.za/dev/UI_footside/page_contact.html" },
                    License = new License() { Name = "Data Licences", Url = "https://docs.google.com/document/d/e/2PACX-1vT8ajcogJEEo0ZC9BGIej_jOH2EV8lMFrwOu8LB4K9pDq7Tki94mUoVxU8hGM-J5EL8V3w5o83_TuEl/pub" },
                    TermsOfService = "http://noframe.media.dirisa.org/wiki-1/conditions-of-use?searchterm=conditions"
                });
            });
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

            //Enable CORS policy
            app.UseCors("CORSPolicy");

            //Enable Swagger/UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "v1.0.0");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
