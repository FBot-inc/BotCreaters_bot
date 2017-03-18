﻿using BotCreators.BotModule.Flows.Inputs;

namespace BotCreators.BotModule.Flows.Events
{
    /*
         * Класс событие новое сообщение.
         * Сравнивает событие с произошедшим и если все сходиться дает доступ к потоку
         */
    public class NewMessageEvent : Event
    {
        public bool IsDisplay { get; set; }

        public string Title
        {
            get
            {
                var input = Input as SimpleInput;

                return input?.Pattern;
            }
        }

        public IInput Input { get; set; }

        public bool Validate(string message)
        {
            if (message == null)
            {
                return false;
            }

            return Input != null && Input.IsBelong(message);
        }
    }
}
