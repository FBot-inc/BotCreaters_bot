using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotCreators.Domain;

namespace BotCreators
{
    public class TelegramAdapter
    {
        private Bot _bot;

        public TelegramAdapter(Bot bot)
        {
            _bot = bot;
        }

        public TelegramConversation RetrievalResponse(string text, long chatId)
        {
            var conversation = _bot.RetrievalResponse(text, chatId);
        }
    }

    public class TelegramConversation
    {
    }
}
