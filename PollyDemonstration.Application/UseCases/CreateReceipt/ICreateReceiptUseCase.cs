namespace PollyDemonstration.Application.UseCases.CreateReceipt
{
    public interface ICreateReceiptUseCase
    {
        void SetOutputPort(IOutputPort outputPort);

        Task ExecuteAsync(CreateReceiptInput input, CancellationToken cancellationToken);
    }
}