using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeDoDigital.PhoneBook.Core.Interfaces;
using WeDoDigital.PhoneBook.Infrastructure.Context;
using WeDoDigital.PhoneBook.Infrastructure.Repositories;

namespace WeDoDigital.PhoneBook.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoneBookDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
           
            services.AddTransient<IPhoneBookRepository, PhoneBookRepository>();

            return services;
        }
    }
}
