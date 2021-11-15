using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RoyalOrderManager.Application.Common.Interfaces;
using RoyalOrderManager.Infrastructure.Persistence;
using RoyalOrderManager.Infrastructure.Services;

namespace RoyalOrderManager.Infrastructure;

public static class DependencyInjection {

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {


        // Create database based on configuration
        services.AddTransient<ApplicationDataAccess>();

        // Add the database as an implementation to the interface
        services.AddScoped<IApplicationDataAccess>(provider => provider.GetRequiredService<ApplicationDataAccess>());

        // Service which publishes domain events 
        services.AddScoped<IDomainEventService, DomainEventService>();

        return services;

    }

}
