using System;
using System.Linq;
using BotCreators.Domain;
using Telegram.Bot;

namespace BotCreators
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var api = new TelegramBotClient("261790631:AAGbJaS4tHzPjwNATCnXSp3VI9y7LCX7n1Q");

            var bot = new Bot();


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
                    Console.WriteLine("There is a new message from " + update.Message.Chat.Id + " chat: " +
                                      update.Message.Text);

                    var response = bot.RetrievalResponse(update.Message.Text, update.Message.Chat.Id);

                    Console.WriteLine("Response: " + response.Text);

                    api.SendTextMessageAsync(update.Message.Chat.Id, response.Text);
                }
            }
        }
    }
}
/*var replyKeybord =
    new ReplyKeyboardMarkup(
        new[] {new[] {new KeyboardButton("123")}, new[] {new KeyboardButton("231")}}, true, true);*/

    /*, false, false, 0, replyKeybord*/