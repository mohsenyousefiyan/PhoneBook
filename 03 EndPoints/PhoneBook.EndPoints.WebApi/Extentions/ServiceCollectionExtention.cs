using AutoMapper;
using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.Core.Domain.ApplicationServices.Queries;
using FrameWork.Core.Domain.Data;
using FrameWork.EndPoints.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PhoneBook.Core.ApplicationService.Contacts.CommandHandlers;
using PhoneBook.Core.ApplicationService.Users.CommandHandlers;
using PhoneBook.Core.Domain.Common.Contracts;
using PhoneBook.Core.Domain.Common.Dtos;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.Core.Domain.Contacts.Repositories;
using PhoneBook.Core.Domain.Users.Commands;
using PhoneBook.Core.Domain.Users.Dtos;
using PhoneBook.Core.Domain.Users.Repositories;
using PhoneBook.EndPoints.WebApi.Infra.ActionFilters;
using PhoneBook.Infra.CommonServices;
using PhoneBook.Infra.DAL.SQL;
using PhoneBook.Infra.DAL.SQL.Contacts.Repositories;
using PhoneBook.Infra.DAL.SQL.Users.Repositories;
using System.Text;

namespace PhoneBook.EndPoints.WebApi.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void RegisterMyFrameWorkComponents(this IServiceCollection services)
        {
            services.AddTransient<CommandDispatcher>();            
            services.AddTransient<QueryDispatcher>();
            services.AddTransient<CommandRequestHandler>();
            services.AddTransient<QueryRequestHandler>();
        }
        public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<PhoneBookCommandDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("CommandDbConStr"));
            });

            services.AddDbContext<PhoneBookQueryDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("QueryDbConStr"));
            });

        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, PhoneBookUnitOfWork>();
            services.AddScoped<ICommandContactRepository, EfCommandContactRepository>();
            services.AddScoped<IQueryConactRepository, EfQueryConactRepository>();
            services.AddScoped<ICommandUserRepository, EfCommandUserRepository>();
        }
        public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<CommandHandler<ContactRegisterCommand>, ContactRegisterCommandHandler>();
            services.AddScoped<CommandHandler<ContactUpdateCommand>, ContactEditCommandHandler>();
            services.AddScoped<CommandHandler<ContactDeleteCommand>, ContactDeleteCommandHandler>();
            services.AddScoped<CommandHandler<AddUserLoginHistoryCommand, UserLoginHitoryAddResultDto>, UserAddLoginHistoryCommandHandler>();
        }
        public static void RegisterQueryHandlers(this IServiceCollection services)
        {
           
        }
     
        public static void RegisterCommonServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, JwtTokenService>();

            services.AddScoped<CustomAuthorizeAttribute>();
        }

        public static void RegisterOptions(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddSingleton(GetTokenSetting(configuration));            
        }

        private static TokenSettingDto GetTokenSetting(IConfiguration configuration)
        {
            var tokenSetting = new TokenSettingDto();
            configuration.GetSection("TokenSetting").Bind(tokenSetting);
            return tokenSetting;
        }

        public static void RegisTerthirdParties(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PhoneBook API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenSetting=GetTokenSetting(configuration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var secretkey = Encoding.UTF8.GetBytes(tokenSetting.SecretKey);
                var encryptionkey = Encoding.UTF8.GetBytes(tokenSetting.SecretKey);

                var validationParameters = new TokenValidationParameters
                {                   
                    RequireSignedTokens = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateAudience = true,
                    ValidAudience = tokenSetting.Audience,

                    ValidateIssuer = true,
                    ValidIssuer = tokenSetting.Issuer,

                    TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;

                //options.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuer = true,
                //    ValidateAudience = true,
                //    ValidateLifetime = true,
                //    ValidateIssuerSigningKey = true,
                //    ValidIssuer =tokenSetting.Issuer,
                //    ValidAudience = tokenSetting.Audience, 
                //    IssuerSigningKey = new
                //    SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSetting.SecretKey))
                //};
            });
        }
    }
}
