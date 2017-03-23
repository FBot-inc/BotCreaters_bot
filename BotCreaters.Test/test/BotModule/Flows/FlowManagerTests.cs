using System;
using System.Linq;
using BotCreators.BotModule;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Flows.Inputs;
using NUnit.Framework;

namespace BotCreaters.Test.test.BotModule.Flows
{
    [TestFixture]
    public class FlowManagerTests
    {
        [Test]
        public void AddFlow()
        {
            var flow = new Flow();

            var flowManager = new FlowManager(new Bot(new Guid().ToString()));

            flowManager.AddFlow(flow);

            Assert.Contains(flow, flowManager.GetFlows().ToList());
        }

        [Test]
        public void GetTitles()
        {
            var flow = new Flow(new Guid().ToString())
            {
                Head = new FlowNode
                {
                    Chain = new Chain
                    {
                        Input = new SimpleInput("Hello")
                    }
                }
            };

            var flowManager = new FlowManager(new Bot(new Guid().ToString()));

            flowManager.AddFlow(flow);

            Assert.Contains("Hello", flowManager.GetTitles());

        }
    }
}