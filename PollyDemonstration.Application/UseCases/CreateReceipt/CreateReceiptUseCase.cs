using PollyDemonstration.Application.UseCases.CreateReceipt.Gateways.GitHubApi;

namespace PollyDemonstration.Application.UseCases.CreateReceipt
{
    internal sealed class CreateReceiptUseCase : ICreateReceiptUseCase
    {
        private readonly IGitHubApiGateway _gitHubApiGateway;
        private IOutputPort _outputPort = default!;

        public CreateReceiptUseCase(IGitHubApiGateway gitHubApiGateway)
        {
            _gitHubApiGateway = gitHubApiGateway;
        }

        public async Task ExecuteAsync(CreateReceiptInput input, CancellationToken cancellationToken)
        {
            var name = await _gitHubApiGateway.GetUserAsync(input.Login, cancellationToken);

            if (string.IsNullOrWhiteSpace(name))
            {
                _outputPort.NotFound(CreateReceiptOutput.Fail(CreateReceiptErrors.ReceiptNotCreated));

                return;
            }

            _outputPort.Accepted();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }
    }
}