using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using RoyalOrderManager.Application.Common.PipelineBehaviors;
using System.Reflection;

namespace RoyalOrderManager.Application;

public static class DependencyInjection {

    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;

    }

}
