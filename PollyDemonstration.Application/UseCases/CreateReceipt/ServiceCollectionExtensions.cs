using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PollyDemonstration.Application.UseCases.CreateReceipt.Gateways.GitHubApi;
using Refit;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace PollyDemonstration.Application.UseCases.CreateReceipt
{
    [ExcludeFromCodeCoverage]
    internal static class ServiceCollectionExtensions
    {
        private const string UrlSectionName = "ExternalServices:{0}:Url";

        public static IServiceCollection AddCreateReceiptUseCase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreateReceiptUseCase, CreateReceiptUseCase>();
            services.Decorate<ICreateReceiptUseCase, CreateReceiptUseCaseValidation>();

            services.AddGateways(configuration);

            return services;
        }

        private static IServiceCollection AddGateways(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGitHubApiGateway, GitHubApiGateway>();

            services.AddRefitClient<IGitHubApi>(GetRefitSettings())
                .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration[string.Format(UrlSectionName, "GitHubApi")]));

            return services;
        }

        private static RefitSettings GetRefitSettings()
        {
            return new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IgnoreNullValues = true
                })
            };
        }
    }
}