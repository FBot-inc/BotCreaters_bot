using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
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
        public void CreateNewResponseForInputNodeAndCheckIt()
        {
            //todo Отложил создание теста до добавления класса респонс
        }
    }
}
