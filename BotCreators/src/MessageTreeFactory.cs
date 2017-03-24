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
                    new Response("������. � ���-��� � � ���� ��������� ���� ����� ����� ���-����."),
                    new Response("������ ������?")
                    {
                        ReplyMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton("��"),
                                new KeyboardButton("���")
                            }, true, true)
                    }
                });


            var areYouSure = new InputResponsePair(
                new UserInput("��"),
                new List<Response>
                {
                    new Response("�� ������?")
                    {
                        ReplyMarkup = new ReplyKeyboardMarkup(new []{
                                new KeyboardButton("��"),
                                new KeyboardButton("���")
                            }, true, true)
                    }
                });


            var botHaveBadNews = new InputResponsePair(
                new UserInput("���"),
                new List<Response>
                {
                    new Response("����� � ���� ��� ���� ������ �������...")
                });

            var messageTree = new MessageTree(head);

            messageTree.AddAfter(areYouSure, head);
            messageTree.AddAfter(botHaveBadNews, head);

            messageTree.AddAfter(botHaveBadNews, areYouSure);

            return messageTree;
        }
    }
}