using System;
using System.Collections.Generic;
using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;
using Telegram.Bot.Types;

namespace BotCreators.BotModule.Flows
{
    /*
     * Представлят собой логические потоки в чат боте.
     * Могут начинаться с различных действий например время или новое сообщение
     */
    public class Flow
    {
        public string Id { get; set; }

        public Event StartEvent() => InnerChains[0]?.StartEvent ?? new EmptyEvent();

        public List<InnerChain> InnerChains { get; set; }
    }

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

    public class Event
    {
        
    }


    /*
     * Класс событие новое сообщение.
     * Сравнивает событие с произошедшим и если все сходиться дает доступ к потоку
     */
    public class NewMessageEvent : Event
    {
        public string GeneralStartInput { get; set; }
        public Input Input { get; set; }


        public bool Validate(string message)
        {
            if (message == null)
            {
                return false;
            }

            return Input != null && Input.IsBelong(message);
        }
    }

    public class TimeEvent : Event
    {
        
    }

    /*
     * Класс заглушка для событий когда, например, внутренних цепей еще нет и не откуда брать реальное событие можно взять это
     */
    public class EmptyEvent : Event
    {
        
    }
}
