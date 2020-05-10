using IServersCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServersCore
{
    public class SendMsgService : IMessageBase
    {
        public string SendMessage()
        {
            return "Msg-Message";
        }
    }
}
