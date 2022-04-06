using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot.Types;

namespace Block_10_1
{
    class MessageLog
    {
        public string Time { get; }

        public long ChatID { get;  }

        public string Msg { get; }

        public string FirstName { get; }

        public CancellationToken Token { get; }

        public Update UpdateClientMes { get; }

        public MessageLog(string Textlog, Update update, CancellationToken Token)
        {
            this.Time = DateTime.Now.ToString();
            this.Msg = Textlog;
            this.FirstName = update.Message.Chat.Username;
            this.ChatID = update.Message.Chat.Id;
            this.Token = Token;
            this.UpdateClientMes = update;
        }
    }
}
