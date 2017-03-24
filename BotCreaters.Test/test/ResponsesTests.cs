using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotCreators;
using NUnit.Framework;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotCreaters.Test.test
{
    [TestFixture]
    public class ResponsesTests
    {

        [Test]
        public void CreateInstanceAndCheckParameters()
        {
            const string responseText = "Hello";
            var keybord = new ReplyKeyboardMarkup(new KeyboardButton[]{"FirstButton", "SecondButton"});
            var response = new Response(responseText)
            {
                ReplyMarkup = keybord
            };

            Assert.AreEqual(responseText, response.Text);
            Assert.IsTrue(keybord.Equals(response.ReplyMarkup));
        }


        [Test]
        public void EqualsWithSomeTextAndWithoutNullKeybord()
        {
            var firstResponse = new Response("It's test text");
            var secondResponse = new Response("It's test text");

            var equalResult = firstResponse.Equals(secondResponse);

            Assert.IsTrue(equalResult);
        }

        [Test]
        public void EqualsWithNotSomeTextAndWithoutKeybord()
        {
            var firstResponse = new Response("It's first test text");
            var secondResponse = new Response("It's second text text");

            var equalResult = firstResponse.Equals(secondResponse);

            Assert.IsFalse(equalResult);
        }

        [Test]
        public void EqualsWithSomeTextAndSomeKybord()
        {
            var firstResponse = new Response("It's test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton", "secondButton"})
            };
            var secondResponse = new Response("It's test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton", "secondButton"})
            };

            var equalResult = firstResponse.Equals(secondResponse);

            Assert.IsTrue(equalResult);
        }

        [Test]
        public void EqualsWithSomeTextAndNotSomeKybord()
        {
            var firstResponse = new Response("It's test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton", "secondButton"})
            };
            var secondResponse = new Response("It's test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton1", "secondButton"})
            };

            var equalResult = firstResponse.Equals(secondResponse);

            Assert.IsFalse(equalResult);
        }

        [Test]
        public void EqualsWithNotSomeTextAndSomeKybord()
        {
            var firstResponse = new Response("It's first test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton", "secondButton"})
            };
            var secondResponse = new Response("It's second test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton", "secondButton"})
            };

            var equalResult = firstResponse.Equals(secondResponse);

            Assert.IsFalse(equalResult);
        }

        [Test]
        public void EqualsWithNotSomeTextAndNotSomeKybord()
        {
            var firstResponse = new Response("It's first test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton1", "secondButton"})
            };
            var secondResponse = new Response("It's second test text")
            {
                ReplyMarkup = new ReplyKeyboardMarkup(new KeyboardButton[] {"firstButton", "secondButton1"})
            };

            var equalResult = firstResponse.Equals(secondResponse);

            Assert.IsFalse(equalResult);
        }
    }
}