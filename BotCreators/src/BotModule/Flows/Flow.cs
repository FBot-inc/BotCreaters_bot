using System;
using System.Collections.Generic;
using BotCreators.BotModule.Flows.Events;
using BotCreators.BotModule.Flows.Inputs;
using Telegram.Bot.Types;

namespace BotCreators.BotModule.Flows
{
    /*
     * Представлят собой логические потоки в чат боте.
     * Могут начинаться с различных действий например время или новое сообщение
     */
    public class Flow
    {
        public string Id { get; private set; }
        public string Title => Head?.Chain?.GetTitle();

        public FlowNode Head { get; set; }
        
        public Flow(string id)
        {
            Id = id;
        }

        public Flow()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
