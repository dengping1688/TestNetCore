using IServersCore;
using Microsoft.Extensions.DependencyInjection;
using ServersCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST02.Extensions
{
    public static class MessageSerExtensions
    {
        public static void AddMessage(this IServiceCollection services, Action<MessageServiceBuilder> action)
        {
            // services.AddSingleton<IMessageBase, SendEmailService>();
            var builder = new MessageServiceBuilder(services);
            action(builder);
        }
    }
}
