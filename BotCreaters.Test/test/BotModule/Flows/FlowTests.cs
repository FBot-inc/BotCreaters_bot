using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Flows.Events;
using BotCreators.BotModule.Flows.Inputs;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BotCreaters.Test.test.BotModule.Flows
{
    [TestFixture]
    public class FlowTests
    {
        [Test]
        public void CreateFlowWithId()
        {
            const string id = "how_are_you";
            var flow = new Flow(id);

            var resultId = flow.Id;

            Assert.AreEqual(id, flow.Id);
        }

        [Test]
        public void CreateFlowWithoutId()
        {
            var flow = new Flow();

            var result = flow.Id;

            Assert.AreNotEqual(result, null);
        }


    }
}