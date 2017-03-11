using System;
using System.Collections.Generic;
using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;
using Telegram.Bot.Types;

namespace BotCreators.BotModule.Flows
{
    public class Flow
    {
        public InputFlowNode Head { get; set; }

        private Dictionary<long, InputFlowNode> _currentNodesOfUser = new Dictionary<long, InputFlowNode>();

        public Flow(IInput input)
        {
            if (input == null)
            {
                throw new ArgumentException("Input cannot be null");
            }

            Head = new InputFlowNode(input);
        }

        public Response Conversation(string message, long chatId)
        {
            if (!_currentNodesOfUser.ContainsKey(chatId))
            {
                _currentNodesOfUser.Add(chatId, Head);
            }

            return _currentNodesOfUser[chatId].Input.IsBelong(message)
                ? _currentNodesOfUser[chatId].Response
                : new Response("I do not know answer");

            //todo Необходимо добавить изменение текущего узла
        }

        public InputFlowNode Start()
        {
            return Head;
        }
    }
}
