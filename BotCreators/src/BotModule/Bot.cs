using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators.BotModule
{
    public class Bot
    {
        public MessageTree MessageTree { get; set; }

        public Bot()
        {
            
        }


        public void Conversation(string message, long chatId)
        {
            if (message == null)
            {
                throw new ArgumentException("Message argument cannot be null");
            }
        }

    }

    public class MessageTree
    {
        public List<Response> Responses { get; set; }
        public List<Input> Inputs { get; set; }

        
    }

    public class MessageTreeNode
    {
    
    }

    public class Response
    {
        public string Text { get; set; }
        public ReplyKeyboardMarkup Keyboard { get; set; }
    }

    public class Input
    {
        public string Text { get; set; }
    }
}
