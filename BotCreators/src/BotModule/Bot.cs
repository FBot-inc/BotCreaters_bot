using System;
using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Flows.Events;
using BotCreators.BotModule.Flows.Inputs;
using Telegram.Bot.Types;

namespace BotCreators.BotModule
{
    public class Bot
    {
        public string BotId { get; private set; }

        //todo Удалить flows, заменив предварительно на FlowManager
        public List<Flow> Flows { get; } = new List<Flow>();

        private FlowManager _flowManager;

        public List<SimpleInput> StartInputs { get; } = new List<SimpleInput>();
        public string StartResponse { get; set; }

        public Bot(string botId)
        {
            BotId = botId;
            _flowManager = new FlowManager(this);
        }

        public TelegramResponse Conversation(string message, long chatId)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            if (StartInputs.Any(p => p.IsBelong(message)))
            {
                var response = new TelegramResponse();

                if (StartResponse != null)
                {
                    response.Text = StartResponse;
                }

                var titles = _flowManager.GetTitles();

                if (titles.Any())
                {
                    response.KeyboardButtons = ConverTitleListToKeybordsButton(titles);
                }

                return response;
            }
            
            //todo Реализовать логику получения ответа, если сообщение не является стартовым.
            return null;
        }

        public void AddFlow(Flow flow)
        {
            _flowManager.AddFlow(flow);
        }

        public IReadOnlyCollection<Flow> GetFlows()
        {
            return _flowManager.GetFlows();
        }

        private static KeyboardButton[][] ConverTitleListToKeybordsButton(IReadOnlyList<string> titles)
        {
            var buttons = new KeyboardButton[titles.Count][];

            for (var i = 0; i < titles.Count; i++)
            {
                buttons[i] = new[]
                {
                    new KeyboardButton(titles[i]),
                };
            }

            return buttons;
        }
    }

    public class TelegramResponse
    {
        public string Text { get; set; } = "";
        public KeyboardButton[][] KeyboardButtons { get; set; } = new KeyboardButton[0][];
    }
}