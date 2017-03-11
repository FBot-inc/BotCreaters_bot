using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;
using NUnit.Framework;

namespace BotCreaters.Test.test.BotModule.Flows
{
    [TestFixture]
    public class FlowNodeTests
    {
        [Test]
        public void CreateSimpleInputFlowNodeAndCheckInputFieldValue()
        {
            var input = new Input("hello");
            var inputFlowNode = new InputFlowNode(input);

            Assert.AreEqual(input, inputFlowNode.Input);
        }

        [Test]
        public void CreateSimpleResponseFlowNodeAndCheckTextFieldValue()
        {
            var response = new Response("hi");
            var responseFlowNode = new ResponseFlowNode(response);

            Assert.AreEqual(response, responseFlowNode.Response);
        }

        [Test]
        public void CreateNewResponseForInputNodeAndCheckIt()
        {
            var input = new Input("hello");
            var inputFlowNode = new InputFlowNode(input);
            var response = new Response("hello it's me");

            var responseFlowNode = inputFlowNode.AddResponse(response);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(inputFlowNode, responseFlowNode.Back);
                Assert.AreEqual(response, responseFlowNode.Response);
            });
        }
    }
}
