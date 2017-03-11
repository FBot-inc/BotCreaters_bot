namespace BotCreators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var api = new TelegramBotClient("350817703:AAHSOXYrfX_uWyz0qEWCkzng1YYNZu-mvR0");

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

                if (updates.Result.Any())
                {
                    offset = updates.Result.Max(p => p.Id) + 1;
                }

                foreach (var update in updates.Result)
                {
                    Console.WriteLine("There is a new message from " + update.Message.Chat.Id + " chat: " +
                                      update.Message.Text);

                    var conversation = bot.RetrievalResponse(update.Message.Text, update.Message.Chat.Id);
                    
                    /*var keybord =
                        new ReplyKeyboardMarkup(
                            conversation?.Buttons?.Select(p => new KeyboardButton(p.Text)).ToArray(), true, true);
                    */
                    //api.SendTextMessageAsync(update.Message.Chat.Id, conversation?.Response);
                /*}
            }*/
        }
    }
}