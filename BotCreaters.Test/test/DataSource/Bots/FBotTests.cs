using System.Linq;
using BotCreators.DataSource;
using NUnit.Framework;

namespace BotCreaters.Test.test.DataSource.Bots
{
    [TestFixture]
    public class FBotTests
    {
        [Test]
        public void CheckBotId()
        {
            var bot = BotSource.GetBotById("fbot");

            Assert.AreEqual("fbot", bot.BotId);
        }

        [Test]
        public void CheckStartInputs()
        {
            var bot = BotSource.GetBotById("fbot");

            Assert.IsTrue(bot.StartInputs.Any(p => p.Pattern.Equals("/start")));
        }
    }
}
