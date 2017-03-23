using System;
using System.Collections.Generic;
using System.Linq;

namespace BotCreators.BotModule.Flows
{
    public class FlowManager
    {
        private Bot _bot;
        private readonly List<Flow> _flows = new List<Flow>();
        private readonly Dictionary<string, Flow> _currentFlows = new Dictionary<string, Flow>();

        public FlowManager(Bot bot)
        {
            _bot = bot;
        }

        public void AddFlow(Flow flow)
        {
            if (flow == null)
            {
                throw new ArgumentNullException($"Flow can't be null");
            }

            _flows.Add(flow);
        }

        public List<string> GetTitles()
        {
            return _flows.Select(p => p.Title).Where(p => !p.Equals("")).ToList();
        }
        
        public void GetResponse(string message, string chatId)
        {
            //todo Реальзивовать логику получения ответа, если у пользователя нет начатого потока
            if (GetCurrentFlowForUser(chatId) == null)
            {
                
            }

            //todo Реализовать логику получения ответа, если у пользователя есть начатый поток
        }

        public Flow GetCurrentFlowForUser(string chatId)
        {
            return _currentFlows[chatId];
        }

        public IReadOnlyCollection<Flow> GetFlows()
        {
            return _flows.AsReadOnly();
        }
    }
}