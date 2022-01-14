using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.Core.Domain.ApplicationServices.Queries;
using FrameWork.Core.Domain.Data;
using FrameWork.EndPoints.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.Core.Domain.Contacts.Repositories;
using PhoneBook.Infra.DAL.SQL;
using PhoneBook.Infra.DAL.SQL.Contacts.Repositories;

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
                option.UseSqlServer(configuration.GetConnectionString("CommandDbConnection"));
            });

            services.AddDbContext<PhoneBookQueryDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("QueryDbConnection"));
            });

        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, PhoneBookUnitOfWork>();
            services.AddScoped<ICommandContactRepository, EfCommandContactRepository>();
            services.AddScoped<IQueryConactRepository, EfQueryConactRepository>();            
        }
        public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<CommandHandler<ContactRegisterCommand>>();           
        }
        public static void RegisterQueryHandlers(this IServiceCollection services)
        {
           
        }
     
        public static void RegisterCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            

           
        }

           
    }
}
