using Examination.Core;
using Examination.Core.Repository;
using Examinations.Core.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExaminationSystem
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options => {
                options.AddPolicy("origins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();

                });


            });
            services.AddControllers();
            services.AddScoped < ITestAnswerRepository, TestAnswerRepository > ();
            services.AddScoped<IOptionsRepository, OptionsRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IQuestionsBankRepository, QuestionsBankRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddDbContext<AdminDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetValue<string>("Client:DataBaseConnection"));
            }

            );




            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    
                    options.TokenValidationParameters = new TokenValidationParameters {
                            ValidateIssuer = true,
                            ValidateAudience= false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "myexam.com",
                            IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes("This is my application secret"))


                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("origins");


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
