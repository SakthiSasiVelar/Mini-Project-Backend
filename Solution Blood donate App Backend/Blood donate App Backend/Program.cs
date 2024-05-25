
using Blood_donate_App_Backend.Contexts;
using Blood_donate_App_Backend.Interfaces;
using Blood_donate_App_Backend.Models;
using Blood_donate_App_Backend.Repositories;
using Blood_donate_App_Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                   };

               });


            #region DbContext
            builder.Services.AddDbContext<BloodDonateAppDbContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlDbConnection"))
            );
            #endregion

            #region Repository
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IUserAuthDetailsRepository<int, UserAuthDetails>, UserAuthDetailsAuthDetailsRepository>();
            builder.Services.AddScoped<IRepository<int,RequestBlood> , RequestBloodDetailsRepository>();
            builder.Services.AddScoped<IRepository<int,DonateBlood>, DonateBloodDetailsRepository>();
            builder.Services.AddScoped<IRepository<int,DonationCenter>, DonationCenterRepository>();
            builder.Services.AddScoped<IRepository<int,CenterAdminRelation>, CenterAdminRelationRepository>();
            builder.Services.AddScoped<IRepository<int, Inventory>, InventoryRepositoryDetails>();
            #endregion

            #region Services
            builder.Services.AddScoped<IUserService, UserServiceBL>();
            builder.Services.AddScoped<ITokenService, TokenServiceBL>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
