using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;

namespace BotCreators.BotModule.Flows
{
    public class InputFlowNode
    {
        public IInput Input { get; set; }

        public Response Response => NextNode?.Response;
        
        public ResponseFlowNode NextNode { get; private set; }

        public InputFlowNode(IInput input)
        {
            Input = input;
        }

        public ResponseFlowNode AddResponse(Response response)
        {
            NextNode = new ResponseFlowNode(response, this);

            return NextNode;
        }
    }
}
