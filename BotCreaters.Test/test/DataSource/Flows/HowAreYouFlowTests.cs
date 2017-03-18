using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotCreators.DataSource;
using NUnit.Framework;

namespace BotCreaters.Test.test.DataSource.Flows
{
    [TestFixture]
    public class HowAreYouFlowTests
    {
        [Test]
        public void CheckFlowId()
        {
            var bot = FlowSource.GetFlowById("how_are_you");

            Assert.AreEqual("how_are_you", bot.Id);
        }
    }
}
