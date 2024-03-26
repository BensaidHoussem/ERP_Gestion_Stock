using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InjectionModule{

    public static IServiceCollection AddInjectionModule(this IServiceCollection services){
        services.AddScoped(typeof(IRepoG<>), typeof(RepoG<>));
        services.AddScoped<IDbContextErp,DbContextErp>();
        return services;

    }
    
}