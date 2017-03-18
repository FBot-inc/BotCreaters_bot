using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotCreators.BotModule;
using BotCreators.BotModule.Flows;
using BotCreators.DataSource;
using BotCreators.Exceptions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators
{
    public class BotRanner
    {
        private Bot _bot;
        private TelegramBotClient _api;
        private readonly string _token;

        public static void Main(string[] args)
        {
            new BotRanner("350817703:AAHSOXYrfX_uWyz0qEWCkzng1YYNZu-mvR0").Start();
        }

        public BotRanner(string token)
        {
            _token = token;
        }

        public void Start()
        {
            Run();
        }

        public void Run()
        {
            var me = InitTelegramClient();

            ShowMeInformation(me);

            const string botId = "fbot";

            try
            {
                _bot = BotSource.GetBotById(botId);
            }
            catch (BotNotFoundedException e)
            {
                Console.WriteLine("Can't find bot with ID fbot");
                Console.WriteLine(e);
                throw;
            }


            var offset = 0;

            while (true)
            {
                var updates = _api.GetUpdatesAsync(offset, 100, 100);

                if (updates.Result.Any())
                {
                    offset = updates.Result.Max(p => p.Id) + 1;
                }

                ProcessUpdates(updates);
            }
        }

        private Task<User> InitTelegramClient()
        {
            _api = new TelegramBotClient(_token);
            return _api.GetMeAsync();
        }

        private void ShowMeInformation(Task<User> user)
        {
            Console.WriteLine("Complited the connection to the telegram bot");
            Console.WriteLine("Bot's id: " + user.Result.Id);
            Console.WriteLine("Bot's firstname: " + user.Result.FirstName);
            Console.WriteLine("Bot's username: " + user.Result.Username);
            Console.WriteLine();
        }

        private void ProcessUpdates(Task<Update[]> updates)
        {
            foreach (var update in updates.Result)
            {
                Console.WriteLine("There is a new message from " + update.Message.Chat.Id + " chat: " +
                                  update.Message.Text);

                var response = _bot.Conversation(update.Message.Text, update.Message.Chat.Id);

                SendResponse(response, update);
            }
        }

        private void SendResponse(TelegramResponse response, Update update)
        {
            if (!response.KeyboardButtons.Any())
            {
                _api.SendTextMessageAsync(update.Message.Chat.Id, response?.Text);
                return;
            }

            if (response == null || update == null)
            {
                throw new ArgumentNullException($"Response or update can't be null");
            }

            var keybord = new ReplyKeyboardMarkup(response.KeyboardButtons)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            _api.SendTextMessageAsync(update.Message.Chat.Id, response?.Text, false, false, 0, keybord);
        }
    }
}