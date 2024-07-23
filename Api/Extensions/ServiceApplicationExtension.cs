using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserManagement.Services;

namespace Api.Extensions
{
    public static class ServiceApplicationExtension
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Enter the Bearer [space] Token \r\n\r\n " +
                                   "Example: Bearer hereTheToken",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
        new OpenApiSecurityScheme
            {
                Reference = new  OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
        new List<string>()
        }

    });

            });


            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));





            services.AddCors();

            //Dependency Injection
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;

        }
    }
}
