using IServersCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServersCore
{
    public class SendEmailService : IMessageBase
    {
        public string SendMessage()
        {
            return "Email-Message";
        }
    }
}
