using BotCreators;
using NUnit.Framework;

namespace BotCreaters.Test.test
{
    [TestFixture]
    public class UserInputTests
    {
        [Test]
        public void CreateInstanceAndCheckParameters()
        {
            const string pattern = "Test pattern";
            var userInput = new UserInput(pattern);

            Assert.AreEqual(pattern, userInput.Pattern);
        }

        [Test]
        public void EqualsWithSomePatternParametr()
        {
            var firstUserInput = new UserInput("hello");
            var secondUserInput = new UserInput("hello");

            Assert.IsTrue(firstUserInput.Equals(secondUserInput));
        }

        [Test]
        public void EqualsWithNotSomePatternParametr()
        {
            var firstUserInput = new UserInput("hello");
            var secondUserInput = new UserInput("otherText");

            Assert.IsFalse(firstUserInput.Equals(secondUserInput));
        }
    }
}