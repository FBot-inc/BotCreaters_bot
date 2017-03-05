using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators
{
    public class RequestResult
    {
        public string ChatId { get; set; }
        public string Text { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            

            var api = new TelegramBotClient("261790631:AAGbJaS4tHzPjwNATCnXSp3VI9y7LCX7n1Q");
            
            var me = api.GetMeAsync();

            Console.WriteLine("Complited the connection to the bot");
            Console.WriteLine("Bot's id: " + me.Result.Id);
            Console.WriteLine("Bot's firstname: " + me.Result.FirstName);
            Console.WriteLine("Bot's username: " + me.Result.Username);
            Console.WriteLine();


            var offset = 0;

            while (true)
            {
                var updates = api.GetUpdatesAsync(offset, 100, 100);

                offset = updates.Result.Max(p => p.Id) + 1;
                
                foreach (var update in updates.Result)
                {
                    Console.WriteLine("There is a new message from " + update.Message.Chat.Id + " chat: " + update.Message.Text);

                    
                    var replyKeybord = new ReplyKeyboardMarkup(new[] {new [] {new KeyboardButton("123")}, new[] {new KeyboardButton("231")}  }, true, true);

                    api.SendTextMessageAsync(update.Message.Chat.Id, update.Message.Text, false, false, 0, replyKeybord);
                }
            }
        }
    }
}
