namespace PollyDemonstration.Application.UseCases.CreateReceipt.Gateways.GitHubApi
{
    internal interface IGitHubApiGateway
    {
        Task<string> GetUserAsync(string request, CancellationToken cancellationToken);
    }
}