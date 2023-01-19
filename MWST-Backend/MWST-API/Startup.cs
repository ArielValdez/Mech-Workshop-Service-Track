using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;

namespace MWST_API
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
            // Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Email Verification
            //services.AddIdentity<IdentityUser, IdentityRole>( options =>
            //{
            //    options.Password.RequiredLength = 4;
            //    options.SignIn.RequireConfirmedEmail = true;
            //})
            //    .AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 4;
            //    options.Password.RequiredUniqueChars = 0;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.SignIn.RequireConfirmedAccount = true;
            //});

            // JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options => 
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            services.AddControllers();
            // Swagger Documentation
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MWST API v0");
            });
            // Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Example to use a photo with an id
            // https://stackoverflow.com/questions/23517615/upload-save-and-retrieve-image-from-database-by-using-their-id-in-code-first-met

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
            //    RequestPath = "./Photos"
            //});
        }
    }
}
