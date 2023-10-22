using Mango.Services.RewardAPI.Messaging;
using System.Reflection.Metadata;

namespace Mango.Services.RewardAPI.Extention
{
    public static class ApplicationBuilderExtenstions
    {
        private static IAZureServiceBusConsumer ServiceBusConsumer { get; set; }

        public static IApplicationBuilder UserAzureSerivceBusConsumer(this IApplicationBuilder app)
        {
            ServiceBusConsumer = app.ApplicationServices.GetService<IAZureServiceBusConsumer>();
            var hostApplicationLife = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            hostApplicationLife.ApplicationStarted.Register(OnStart);
            hostApplicationLife.ApplicationStopped.Register(OnStop);

            return app;

        }

        private static void OnStop()
        {
            ServiceBusConsumer.stop();
        }

        private static void OnStart()
        {
            ServiceBusConsumer.start();
        }
    }
}
