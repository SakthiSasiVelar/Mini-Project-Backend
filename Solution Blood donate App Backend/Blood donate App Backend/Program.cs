
using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DbContext
            builder.Services.AddDbContext<BloodDonateAppDbContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlDbConnection"))
            );
            #endregion

            #region Repository
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, UserAuthDetails>, UserAuthDetailsAuthDetailsRepository>();
            builder.Services.AddScoped<IRepository<int,RequestBlood> , RequestBloodDetailsRepository>();
            builder.Services.AddScoped<IRepository<int,DonateBlood>, DonateBloodDetailsRepository>();
            builder.Services.AddScoped<IRepository<int,DonationCenter>, DonationCenterRepository>();
            builder.Services.AddScoped<IRepository<int,CenterAdminRelation>, CenterAdminRelationRepository>();
            builder.Services.AddScoped<IRepository<int, Inventory>, InventoryRepositoryDetails>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
