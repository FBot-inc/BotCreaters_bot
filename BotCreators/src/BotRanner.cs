using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BotCreators
{
    public class BotRanner
    {
        public static void Main(string[] args)
        {
            var telegramClient = new TelegramBotClient("350817703:AAHSOXYrfX_uWyz0qEWCkzng1YYNZu-mvR0");

            var messageTree = MessageTreeFactory.CreateMessageTree();

            var offset = -1;

            while (true)
            {
                var updateTask = telegramClient.GetUpdatesAsync(offset, 100, 100);

                //todo Добавить обработку исключения при неудачном получение обновлений

                if (updateTask.Result.Any())
                {
                    offset = updateTask.Result.Max(p => p.Id) + 1;
                }

                foreach (var update in updateTask.Result)
                {
                    var responses = messageTree.GetResponse(update.Message.Text, update.Message.Chat.Id);

                    foreach (var response in responses)
                    {
                        telegramClient.SendTextMessageAsync(update.Message.Chat.Id, response.Text, false, false, 0,
                            response.ReplyMarkup);
                    }
                }
            }
        }
    }
}