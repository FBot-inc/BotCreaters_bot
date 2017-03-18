using System;
using System.Collections.Generic;
using BotCreators.BotModule.Flows.Conditions;
using BotCreators.BotModule.Flows.Events;
using BotCreators.BotModule.Flows.Responses;

namespace BotCreators.BotModule.Flows
{
    /*
         * Класс предстовляет собой внутренную цепочки потока
         * Данные цепочки реагируют только на одно событие и на этом их жизнь прекращается
         * В то время как поток может хранить несколько подряд идущих входных событий
         */
    public class InnerChain
    {
        public string Id { get; set; }
        public Event StartEvent { get; set; }

        public List<Action> Action { get; set; }

        public List<Response> Responses { get; set; }
    }
}
