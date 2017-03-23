using System.Collections.Generic;

namespace BotCreators.BotModule.Flows
{
    public class FlowNode
    {
        public FlowNode(Chain chain)
        {
            Chain = chain;
        }

        public FlowNode() { }

        public Chain Chain;
        public List<Chain> NextChains;
    }
}
