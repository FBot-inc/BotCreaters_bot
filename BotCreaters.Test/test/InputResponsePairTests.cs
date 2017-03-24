using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotCreators;
using NUnit.Framework;

namespace BotCreaters.Test.test
{
    [TestFixture]
    public class InputResponsePairTests
    {
        [Test]
        public void CreateInstanceAndCheckUserInputParameter()
        {
            var pair = new InputResponsePair(new UserInput("hello"), new List<Response> { new Response("hello") });

            Assert.IsTrue(new UserInput("hello").Equals(pair.Input));
        }
        [Test]
        public void CreateInstanceAndCheckResponsesParameter()
        {
            var pair = new InputResponsePair(new UserInput("hello"), new List<Response> { new Response("hello") });

            CollectionAssert.AreEqual(new List<Response>{new Response("hello")}, pair.Responses);
        }
        [Test]
        public void EqualsWithSomeParameters()
        {
            var firstPair = new InputResponsePair(new UserInput("hello"), new List<Response> { new Response("hello") });
            var secondPair = new InputResponsePair(new UserInput("hello"), new List<Response> {new Response("hello")});

            Assert.IsTrue(firstPair.Equals(secondPair));
        }

        [Test]
        public void EqualsWithNotSomeParameters()
        {
            var firstPair = new InputResponsePair(new UserInput("hello"), new List<Response> { new Response("hello") });
            var secondPair = new InputResponsePair(new UserInput("hello1234"), new List<Response> { new Response("hello1234") });

            Assert.IsFalse(firstPair.Equals(secondPair));
        }
    }
}