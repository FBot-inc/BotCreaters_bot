using System;
using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = new TelegramBotClient("350817703:AAHSOXYrfX_uWyz0qEWCkzng1YYNZu-mvR0");

            //todo вынести в отдельный класс
            const string botStartMessage = "Чем я могу вам помочь";

            var input = new Input("Получить консультацию");
            var flow = new Flow(input);

            flow.Start()
                .AddResponse(new Response("Отлично! Это как раз то в чем я могу вам помочь."))
                .End();

            var bot = new Bot
            {
                StartMessage = botStartMessage,
                Flows = new List<Flow>
                {
                    flow
                }
            };

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

                if (updates.Result.Any())
                    offset = updates.Result.Max(p => p.Id) + 1;

                foreach (var update in updates.Result)
                {
                    Console.WriteLine("There is a new message from " + update.Message.Chat.Id + " chat: " +
                                      update.Message.Text);

                    var response = bot.Conversation(update.Message.Text, update.Message.Chat.Id);

                    //todo сделать учет того есть ли клавиатура

                    api.SendTextMessageAsync(update.Message.Chat.Id, response?.Text, false, false, 0, new ReplyKeyboardMarkup(response?.KeyboardButtons));
                }
            }
        }
    }
}