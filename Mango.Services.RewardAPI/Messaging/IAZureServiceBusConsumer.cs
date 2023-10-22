namespace Mango.Services.RewardAPI.Messaging
{
    public interface IAZureServiceBusConsumer
    {
        Task start();
        Task stop();
    }
}
