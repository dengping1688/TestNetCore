using IServersCore;
using Microsoft.Extensions.DependencyInjection;
using ServersCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST02.Extensions
{
    public class MessageServiceBuilder
    {
        public IServiceCollection ServiceCollection { get; set; }
        public MessageServiceBuilder(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }
        public void UserEmail()
        {
            ServiceCollection.AddSingleton<IMessageBase, SendEmailService>(); 
        }
        public void UserSms()
        {
            ServiceCollection.AddSingleton<IMessageBase, SendMsgService>();
        }
    }
}
