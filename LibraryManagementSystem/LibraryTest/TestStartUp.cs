﻿using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTest
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public  void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            TestInitializer.RegisterMockRepositories(services);
            services.AddDbContext<LibraryDbContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("Dbcs")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryManagementSystem", Version = "v1" });
            });
            services.AddTransient<IBook, BookRepository>();
            services.AddTransient<IBookStatus, BookStatusRepository>();
            services.AddTransient<IDesignation, DesignationRepository>();
            services.AddTransient<IEbook, EbookRepository>();
            services.AddTransient<IFaculty, FacultyRepository>();
            services.AddTransient<IStudent, StudentRepostory>();
            services.AddTransient<IIssue, IssueRepostory>();
            services.AddTransient<ISale, SaleRepostory>();
            services.AddTransient<ISupplier, SupplierRepository>();

            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryManagementSystem v1");
                    c.RoutePrefix = string.Empty;
                });

            }


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

