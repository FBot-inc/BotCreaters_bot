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

        public List<Flow> Flows { get; } = new List<Flow>();
        public List<SimpleInput> StartInputs { get; } = new List<SimpleInput>();

        public Bot(string botId)
        {
            BotId = botId;
        }

        public TelegramResponse Conversation(string message, long chatId)
        {
            var response = new TelegramResponse();

            if (IsStartMessage(message))
            {
                var flowTitles = FetchTitleFromDisplayFlow();

                response.KeyboardButtons = ConverTitleListToKeybordsButton(flowTitles);
            }

            return response;
        }

        private bool IsStartMessage(string message)
        {
            return StartInputs.Any(p => p.IsBelong(message));
        }

        private List<string> FetchTitleFromDisplayFlow()
        {
            var titles = new List<string>();

            foreach (var flow in Flows)
            {
                var flowStartEvent = (NewMessageEvent) flow.StartEvent;

                if (flowStartEvent == null) continue;

                if (flowStartEvent.IsDisplay)
                {
                    titles.Add(flowStartEvent.Title);
                }
            }

            return titles;
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
        public string Text { get; set; }
        public KeyboardButton[][] KeyboardButtons { get; set; } = new KeyboardButton[0][];
    }
}