using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.Models;

namespace Hand2TradeAP.Services
{
    public interface IChatService
    {
        Task Connect(string[] groupNames);
        Task Disconnect(string[] groupNames);
        Task SendMessageToGroup(string user, TextMessage textMessage);
        void RegisterToReceiveMessage(Action<string, string> GetMessageAndUser);
        void RegisterToReceiveMessageFromGroup(Action<string, string, string> GetMessageAndUserFromGroup);
    }
}
