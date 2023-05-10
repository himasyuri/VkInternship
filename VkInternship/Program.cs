
using Microsoft.EntityFrameworkCore;
using Npgsql;
using VkInternship.Models;
using VkInternship.Repositories;
using VkInternship.Services;

namespace VkInternship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conStrBuilder = new NpgsqlConnectionStringBuilder(
                builder.Configuration.GetConnectionString("VkInternship"));
            conStrBuilder.Password = builder.Configuration["DbPassword"];

            string connection = conStrBuilder.ConnectionString;
            Globals.Connection = connection;

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationContext>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICustomLoggerService, CustomLoggerService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}