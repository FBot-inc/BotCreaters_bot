using System.Collections.Generic;

namespace BotCreators.BotModule.Flows
{
    public class FlowNode
    {
        public FlowNode(Chain chain)
        {
            Current = chain;
        }

        public FlowNode() { }

        public Chain Current;
        public List<Chain> NextChains;
    }
}
