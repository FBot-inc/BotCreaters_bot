using BotCreators.BotModule.Inputs;
using NUnit.Framework;

namespace BotCreaters.Test.test.BotModule.Inputs
{
    [TestFixture]
    public class InputTests
    {
        [Test]
        public void CreateInputAndCheckWithRightData()
        {
            var input = new Input("hello world");

            var result = input.IsBelong("hello world");

            Assert.IsTrue(result);
        }

        [Test]
        public void CreateInputAndCheckWithWrongData()
        {
            var input = new Input("hello world");

            var result = input.IsBelong("hello world1423423");

            Assert.IsFalse(result);
        }

       
    }
}
