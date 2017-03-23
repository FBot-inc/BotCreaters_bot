using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators
{
    public class BotRanner
    {
        public static void Main(string[] args)
        {
            var telegramClient = new TelegramBotClient("350817703:AAHSOXYrfX_uWyz0qEWCkzng1YYNZu-mvR0");

            var messageTree = new MessageTree(
                new UserInput {Pattern = "/start"},
                new List<Response>
                {
                    new Response {Text = "Привет. Я чат-бот и я могу расказать тебе зачем нужны чат-боты."},
                    new Response
                    {
                        Text = "Хочешь узнать?",
                        ReplyMarkup = new ReplyKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new KeyboardButton("Да"),
                                new KeyboardButton("Нет")
                            }
                        }, true, true)
                    }
                });


            var areYouSure = new MessageTreeNode
            {
                Current = new InputResponsePair
                {
                    Input = new UserInput
                    {
                        Pattern = "Да"
                    },
                    Responses = new List<Response>
                    {
                        new Response
                        {
                            Text = "Ты уверен?",
                            ReplyMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new[]
                                {
                                    new KeyboardButton("Да"),
                                    new KeyboardButton("Нет")
                                }
                            }, true, true)
                        }
                    }
                }
            };


            var botHaveBadNews = new MessageTreeNode
            {
                Current = new InputResponsePair
                {
                    Input = new UserInput
                    {
                        Pattern = "Нет"
                    },
                    Responses = new List<Response>
                    {
                        new Response
                        {
                            Text = "Тогда у меня для тебя плохие новости..."
                        }
                    }
                }
            };


            messageTree.Head.NextNodes.Add(botHaveBadNews);
            messageTree.Head.NextNodes.Add(areYouSure);

            messageTree.Head.NextNodes.FirstOrDefault(p => p.Current.Input.Compare("Да"))?.NextNodes.Add(botHaveBadNews);

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


    public class MessageTree
    {
        public MessageTreeNode Head { get; }

        public Response StubResponse = new Response
        {
            Text = "Я не знаю, что ответить тебе."
        };

        private readonly Dictionary<long, List<MessageTreeNode>> _currentNodes =
            new Dictionary<long, List<MessageTreeNode>>();

        public MessageTree(UserInput headInput, List<Response> headResponses)
        {
            if (headInput == null || headResponses == null || !headResponses.Any())
            {
                throw new ArgumentNullException();
            }

            Head = new MessageTreeNode
            {
                Current = new InputResponsePair
                {
                    Input = headInput,
                    Responses = headResponses
                }
            };
        }

        public List<Response> GetResponse(string message, long chatId)
        {
            if (!_currentNodes.ContainsKey(chatId))
            {
                if (!Head.Current.Input.Compare(message))
                {
                    return new List<Response> {StubResponse};
                }

                if (Head.NextNodes.Any())
                {
                    _currentNodes.Add(chatId, Head.NextNodes);
                }

                return Head.Current.Responses;
            }

            var suitableResponse = _currentNodes[chatId].FirstOrDefault(p => p.Current.Input.Compare(message));

            if (suitableResponse == null)
            {
                return new List<Response> {StubResponse};
            }

            if (!suitableResponse.NextNodes.Any())
            {
                _currentNodes.Remove(chatId);
            }
            else
            {
                _currentNodes[chatId] = suitableResponse.NextNodes;
            }

            return suitableResponse.Current.Responses;
        }
    }

    public class MessageTreeNode
    {
        public InputResponsePair Current { get; set; }
        public List<MessageTreeNode> NextNodes { get; } = new List<MessageTreeNode>();
    }

    public class InputResponsePair
    {
        public UserInput Input { get; set; }
        public List<Response> Responses { get; set; } = new List<Response>();
    }

    public class UserInput
    {
        public string Pattern { get; set; } = "";

        public UserInput()
        {
        }

        public bool Compare(string message)
        {
            return Pattern.Equals(message);
        }
    }

    public class Response
    {
        public string Text { get; set; } = "";
        public IReplyMarkup ReplyMarkup { get; set; }
    }
}