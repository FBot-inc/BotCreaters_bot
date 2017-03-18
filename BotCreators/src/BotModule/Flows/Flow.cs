using System;
using System.Collections.Generic;
using BotCreators.BotModule.Flows.Events;
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
        public Event StartEvent => Head?.Current?.StartEvent;
        public FlowNode Head;

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
