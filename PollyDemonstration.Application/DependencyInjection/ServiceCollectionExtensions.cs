using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PollyDemonstration.Application.UseCases.CreateReceipt;
using System.Diagnostics.CodeAnalysis;

namespace PollyDemonstration.Application.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCreateReceiptUseCase(configuration);

            return services;
        }
    }
}