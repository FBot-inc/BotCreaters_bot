using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotCreators.BotModule;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BotCreaters.Test.test.BotModule
{
    [TestFixture]
    public class BotTests
    {
        [Test]
        public void CreateBot()
        {
            var bot = new Bot("fbot");

            Assert.AreEqual("fbot", bot.BotId);
        }
    }
}
