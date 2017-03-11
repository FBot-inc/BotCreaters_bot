using System;
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

        [Test]
        public void CreateInputWithNullValue()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var input = new Input(null);
            });
        }

        [Test]
        public void EqualsWithOtherClass()
        {
            var input = new Input("asdf");

            Assert.AreNotEqual(input, "asdf");
        }

        [Test]
        public void EqualsWithRightObject()
        {
            var input1 = new Input("asdf");
            var input2 = new Input("asdf");

            Assert.AreEqual(input2, input1);
        }

        [Test]
        public void EqualsWithWrongData()
        {
            var input1 = new Input("asdf");
            var input2 = new Input("asdf114234");


            Assert.AreNotEqual(input1, input2);
        }
    }
}
