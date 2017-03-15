using System;
using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
using BotCreators.DataSource;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators.BotModule
{
    public class Bot
    {
        public List<Flow> Flows { get; set; } = new List<Flow>();


        //вводы при которых показывается первый экран
        public List<Input> StartInputs = new List<Input>
        {
            new Input("/start")
        };

        public Bot()
        {
            try
            {
                Flows.Add(FlowSource.GetFlowById("flow_about_bot"));
                Flows.Add(FlowSource.GetFlowById("flow_get_action"));
            }
            catch (TypeInitializationException e)
            {
                Console.WriteLine(e.InnerException);
            }
        }

        public TelegramResponse Conversation(string message, long chatId)
        {
            if (StartInputs.Any(p => p.IsBelong(message)))
            {
                var buttonsList = Flows.Select(flow => flow.StartEvent()).OfType<NewMessageEvent>().Select(startEvent => startEvent.GeneralStartInput).ToList();

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
