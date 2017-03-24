using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;

namespace BotCreators
{
    public class MessageTree
    {
        private readonly MessageTreeNode _head;
        private readonly List<MessageTreeNode> _nodes = new List<MessageTreeNode>();

        public Response StubResponse = new Response("Я не знаю, что ответить тебе.");


        private readonly Dictionary<long, List<MessageTreeNode>> _currentNodes =
            new Dictionary<long, List<MessageTreeNode>>();

        public MessageTree(InputResponsePair headInputResponsePair)
        {
            if (headInputResponsePair.Input == null || headInputResponsePair.Responses == null ||
                !headInputResponsePair.Responses.Any())
            {
                throw new ArgumentNullException();
            }

            _head =
                new MessageTreeNode(new InputResponsePair(headInputResponsePair.Input, headInputResponsePair.Responses));

            _nodes.Add(_head);
        }

        public List<Response> GetResponse(string message, long chatId)
        {
            if (!_currentNodes.ContainsKey(chatId))
            {
                if (!_head.Current.Input.Compare(message))
                {
                    return new List<Response> {StubResponse};
                }

                if (_head.NextNodes.Any())
                {
                    _currentNodes.Add(chatId, _head.NextNodes);
                }

                return _head.Current.Responses;
            }

            var suitableResponse = _currentNodes[chatId].FirstOrDefault(p => p.Current.Input.Compare(message));

            if (suitableResponse == null)
            {
                return new List<Response> {StubResponse};
            }

            if (!suitableResponse.NextNodes.Any())
            {
                _currentNodes.Remove(chatId);
            }
            else
            {
                _currentNodes[chatId] = suitableResponse.NextNodes;
            }

            return suitableResponse.Current.Responses;
        }

        public void AddAfter(InputResponsePair forAdd, InputResponsePair after)
        {
            if (forAdd == null || after == null)
            {
                throw new ArgumentNullException();
            }

            var foundAfterPair = _nodes.FirstOrDefault(p => p.Current.Equals(after));

            if (foundAfterPair == null)
            {
                //todo добавить метод quals и протестировать их
                //todo заменить на более подходящее исключение, говорящее что пара после которой добавлять не найдена
                throw new InstanceNotFoundException();
            }

            _nodes.Add(new MessageTreeNode(forAdd));
            foundAfterPair.NextNodes.Add(new MessageTreeNode(forAdd));
        }
    }

    public class MessageTreeNode
    {
        public MessageTreeNode(InputResponsePair currentPair)
        {
            Current = currentPair;
        }

        public InputResponsePair Current { get; set; }
        public List<MessageTreeNode> NextNodes { get; } = new List<MessageTreeNode>();
    }
}