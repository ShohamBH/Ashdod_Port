<<<<<<< HEAD

using Ashdod_Port.Api.Controllers;
using Ashdod_Port.Api.Middleware;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Data;
using Ashdod_Port.Service;
using Clean.Core.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Ashdod_Port.Api
=======
//using Ashdod_Port.Entities;
//using Ashdod_Port.Interface;

//namespace Ashdod_Port
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);
//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            //services.AddSingleton<IDataContext, FakeContextServies>();


//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();

//            app.MapControllers();

//            app.Run();
//        }
//    }
//}



using Ashdod_Port.Core.Interface;


namespace Ashdod_Port
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
<<<<<<< HEAD
            var configuration = builder.Configuration;
            // הוספת שירותים למיכל השירותים
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });

            builder.Services.AddScoped<IContrainerService, ContrainerService>();
                builder.Services.AddScoped<IImporterService, ImporterService>();
                builder.Services.AddScoped<ISupplierService, SupplierService>();
                //builder.Services.AddSingleton<IDataContext, DataContextServies>();
                builder.Services.AddDbContext<DataContextServies>();

                // הוספת FakeContextServies כשרות
                //builder.Services.AddSingleton<IDataContext, FakeContextServies>();


                builder.Services.AddAutoMapper(typeof(MapperProfile));

                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        ClockSkew = TimeSpan.Zero,//בודק האם לא פג התוקף
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });



                var app = builder.Build();

                // קביעת הגדרות לשירותים
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseMiddleware<LogMiddleware>();

                app.UseHttpsRedirection();

                app.UseAuthentication();

                app.UseAuthorization();

                app.MapControllers();


                app.Run();
            }
    }
    }
=======

            // הוספת שירותים למיכל השירותים
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // הוספת FakeContextServies כשרות
            builder.Services.AddSingleton<IDataContext, FakeContextServies>();

            var app = builder.Build();

            // קביעת הגדרות לשירותים
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
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
