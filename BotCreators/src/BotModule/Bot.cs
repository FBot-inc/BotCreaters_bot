using System;
using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Flows.Events;
using BotCreators.BotModule.Flows.Inputs;
using BotCreators.DataSource;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators.BotModule
{
    public class Bot
    {
        public string BotId { get; private set; }

        public List<Flow> Flows { get; } = new List<Flow>();
        public List<Input> StartInputs { get; } = new List<Input>();
        
        public Bot(string botId)
        {
            BotId = botId;
        }

        public TelegramResponse Conversation(string message, long chatId)
        {
            if (StartInputs.Any(p => p.IsBelong(message)))
            {
                var buttonsList = Flows.Select(flow => flow.StartEvent).OfType<NewMessageEvent>().Select(startEvent => startEvent.Title).ToList();

                var keybordButtons = new KeyboardButton[buttonsList.Count][];

                for (var i = 0; i < keybordButtons.Length; i++)
                {
                    keybordButtons[i] = new []
                    {
                        new KeyboardButton(buttonsList[i])
                    };
                }

                //todo добавить добавление кнопок только с доступными правами
                //todo добавление стратового текста в ответ с условием первый раз пользователь или нет


                var response = new TelegramResponse
                {
                    Text = "hello",
                    KeyboardButtons = keybordButtons
                };

                return response;
            }


            //todo заглушка необходимо перписать
            return new TelegramResponse
            {
                Text = "stub"
            };
        }
    }

    public class TelegramResponse
    {
        public string Text { get; set; }
        public KeyboardButton[][] KeyboardButtons { get; set; } = new KeyboardButton[0][];
    }
}
