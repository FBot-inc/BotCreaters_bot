using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;

namespace BotCreators.BotModule.Flows
{
    public class Flow
    {
        private string _input;

        public Flow(string input)
        {
            _input = input;
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

        public FlowResponseNode AddResponse(Response response)
        {
            _nextResponseNode = new FlowResponseNode(response, this);

            return _nextResponseNode;
        }
    }

    public class FlowResponseNode
    {
        public InputFlowNode Back { get; set; }

        public Response Response { get; set; }

        public FlowResponseNode(Response response)
        {
            Response = response;
        }

        public FlowResponseNode(Response response, InputFlowNode prevInputFlowNode)
        {
            Response = response;
            Back = prevInputFlowNode;
        }
    }
}
