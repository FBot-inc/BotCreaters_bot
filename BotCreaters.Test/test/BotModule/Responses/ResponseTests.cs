using System;
using BotCreators.BotModule.Responses;
using NUnit.Framework;

namespace BotCreaters.Test.test.BotModule.Responses
{
    [TestFixture]
    public class ResponseTests
    {
        [Test]
        public void CreateResponseAndChectTextField()
        {
            var response = new Response("hello");

            Assert.AreEqual("hello", response.Text);
        }

        [Test]
        public void CreateResponseWithNullArgument()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var response = new Response(null);
            });
        }

        [Test]
        public void EqualsWithRightData()
        {
            var response1 = new Response("hello");
            var response2 = new Response("hello");

            var result = response1.Equals(response2);

            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsWithWrongData()
        {
            var response1 = new Response("hello");
            var response2 = new Response("41234123");

            var result = response1.Equals(response2);

            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsWithNull()
        {
            var response1 = new Response("hello");

            var result = response1.Equals(null);

            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsWithOtherClass()
        {
            var response1 = new Response("hello");

            var result = response1.Equals("asdfasd");

            Assert.IsFalse(result);
        }
    }
}
