using System;
using System.Collections.Generic;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreators.BotModule
{
    public class Bot
    {
        public List<Flow> Flows { get; set; } = new List<Flow>();
        public string StartMessage = "Main menu";

        public Bot()
        {
            
        }

        public TelegramResponse Conversation(string message, long chatId)
        {
            if (message == "/start")
            {
                var telegramResponse = new TelegramResponse
                {
                    Text = StartMessage,
                    KeyboardButtons = new KeyboardButton[Flows.Count][]
                };
                
                for (var i = 0; i < Flows.Count; i++)
                {
                    //todo надо будте исправить это место asdf
                    telegramResponse.KeyboardButtons[i] = new KeyboardButton[] {(Flows[i].Head.Input as Input)?.Pattern ?? "asdf"};
                }

                return telegramResponse;
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
        public KeyboardButton[][] KeyboardButtons { get; set; }
    }
}
