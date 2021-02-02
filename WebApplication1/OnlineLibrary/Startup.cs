using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Mapping;
using BusinessLayer.Services;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly string AngularOrigins;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AngularOrigins = Configuration["Cors:Rules:0:Name"];
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LibraryDatabase")));
            services.AddCors(options =>
            {
                options.AddPolicy(name : AngularOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(Configuration["Cors:Rules:0:Origin"])
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseCors(AngularOrigins);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
