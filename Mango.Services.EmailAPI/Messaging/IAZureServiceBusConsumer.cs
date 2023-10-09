namespace Mango.Services.EmailAPI.Messaging
{
    public interface IAZureServiceBusConsumer
    {
        Task start();
        Task stop();
    }
}
