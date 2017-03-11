using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule.Responses;

namespace BotCreators.BotModule.Flows
{
    public class ResponseFlowNode
    {
        public InputFlowNode PreviousNode { get; set; }
        
        public Response Response { get; set; }

        public bool IsEnd { get; private set; }

        public List<InputFlowNode> NextInputNodes = new List<InputFlowNode>();

        public ResponseFlowNode(Response response)
        {
            Response = response;
        }

        public ResponseFlowNode(Response response, InputFlowNode prevInputFlowNode)
        {
            Response = response;
            PreviousNode = prevInputFlowNode;
        }

        public void End()
        {
            IsEnd = true;
        }


        //Метод пока не протестирован 
        /*public InputFlowNode Return()
        {
            if (NextInputNodes.Any())
            {
                End();
            }

            return PreviousNode;
        }*/
    }
}