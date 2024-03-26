using AutoMapper.Extensions.ExpressionMapping;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Inject{

    public static IServiceCollection InjectionAll(this IServiceCollection services){
        
        services.AddAutoMapper(cfg=> { cfg.AddExpressionMapping(); },typeof(MappingProfile).Assembly);
        services.AddScoped(typeof(IServiceDto<,>),typeof(ServiceDto<,>));
        services.AddMediatR(typeof(AccessMediatR).Assembly);
        services.AddInjectionModule();
  
        return services;
    }
}