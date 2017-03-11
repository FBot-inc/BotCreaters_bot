using BotCreators.BotModule.Inputs;

namespace BotCreators.BotModule.Flows
{
    public class Flow
    {
        private string _input;

        public Flow(string input)
        {
            this._input = input;
        }

        public Input Head { get; set; }
    }

    public class InputFlowNode
    {
        public IInput Input { get; set; }

        private FlowResponseNode _nextResponseNode;

        public InputFlowNode(IInput input)
        {
            Input = input;
        }


    }

    public class FlowResponseNode
    {
    }
}
