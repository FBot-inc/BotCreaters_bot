using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators.Domain
{
    public class Response
    {
        public string Text { get; set; }
        public ReplyKeyboardMarkup ReplyKeyboardMarkup { get; set; }
    }
}
