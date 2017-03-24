using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators
{
    public class MessageTreeFactory
    {
        public static MessageTree CreateMessageTree()
        {
            var head = new InputResponsePair(
                new UserInput("/start"), 
                new List<Response>
                {
                    new Response("Привет. Я чат-бот и я могу расказать тебе зачем нужны чат-боты."),
                    new Response("Хочешь узнать?")
                    {
                        ReplyMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton("Да"),
                                new KeyboardButton("Нет")
                            }, true, true)
                    }
                });


            var areYouSure = new InputResponsePair(
                new UserInput("Да"),
                new List<Response>
                {
                    new Response("Ты уверен?")
                    {
                        ReplyMarkup = new ReplyKeyboardMarkup(new []{
                                new KeyboardButton("Да"),
                                new KeyboardButton("Нет")
                            }, true, true)
                    }
                });


            var botHaveBadNews = new InputResponsePair(
                new UserInput("Нет"),
                new List<Response>
                {
                    new Response("Тогда у меня для тебя плохие новости...")
                });

            var messageTree = new MessageTree(head);

            messageTree.AddAfter(areYouSure, head);
            messageTree.AddAfter(botHaveBadNews, head);

            messageTree.AddAfter(botHaveBadNews, areYouSure);

            return messageTree;
        }
    }
}