using System.Collections.Generic;

namespace BotCreators.BotModule.Flows
{
    public class FlowNode
    {
        public InnerChain Current;
        public List<InnerChain> NextChains;
    }
}
