using BotCreators.BotModule.Responses;

namespace BotCreators.BotModule.Flows
{
    public class ResponseFlowNode
    {
        public InputFlowNode Back { get; set; }

        public bool IsEnd { get; private set; }


        public Response Response { get; set; }

        public ResponseFlowNode(Response response)
        {
            Response = response;
        }

        public ResponseFlowNode(Response response, InputFlowNode prevInputFlowNode)
        {
            Response = response;
            Back = prevInputFlowNode;
        }

        public void End()
        {
            IsEnd = true;
        }
    }
}