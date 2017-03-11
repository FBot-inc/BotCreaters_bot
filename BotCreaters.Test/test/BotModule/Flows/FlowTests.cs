using System;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;
using NUnit.Framework;

namespace BotCreaters.Test.test.BotModule.Flows
{
    [TestFixture]
    public class FlowTests
    {
        [Test]
        public void CreateFlowWithNullArgument()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var flow = new Flow(null);
            });
        }

        [Test]
        public void CreateFlowWithRightDataAndCheckHeadElement()
        {
            var input = new Input("hello");
            var flow = new Flow(input);

            Assert.AreEqual(input, flow.Head.Input);
        }

        [Test]
        public void CreateFlowWithOneResponse()
        {
            var input = new Input("hello");
            var flow = new Flow(input);

            var response = new Response("hi");

            flow.Head.AddResponse(response);

            Assert.AreEqual(response, flow.Head.Response);
        }

        [Test]
        public void TestTextOfConversationOnExampleOfShortDialog()
        {
            var input = new Input("hello");
            var flow = new Flow(input);
            var response = new Response("hi");

            flow.Head.AddResponse(response);

            var responseOfConversation = flow.Conversation("hello", 1234L);
            
            Assert.AreEqual("hi", responseOfConversation.Text); 
        }

        [Test]
        public void CreateResponseWithHelpStartAndAddResponseMetods()
        {
            var input = new Input("hi");
            var flow = new Flow(input);

            var response = new Response("Hello");

            flow.Start()
                .AddResponse(response)
                .End();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(response, flow.Head.Response);
                Assert.IsTrue(flow.Head.NextNode.IsEnd);
            });
        }
    }
}