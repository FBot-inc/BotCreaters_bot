using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule;
using BotCreators.BotModule.Flows;
using BotCreators.BotModule.Inputs;
using BotCreators.BotModule.Responses;
using NUnit.Framework;
using Telegram.Bot.Types;

namespace BotCreaters.Test.test.BotModule
{
    //todo попробовать упростить
    //todo разобраться с проверкой ступенчатых массивов
    [TestFixture]
    public class BotTests
    {
        [Test]
        public void ConversationWithStartCommand()
        {
            const string inputMessage = "/start";
            const long chatId = 1234L;
            const string botStartMessage = "Чем я могу вам помочь";

            var input = new Input("Получить консультацию");
            var flow = new Flow(input);

            flow.Start()
                .AddResponse(new Response("Отлично! Это как раз то в чем я могу вам помочь."))
                .End();

            var bot = new Bot
            {
                StartMessage = botStartMessage,
                Flows = new List<Flow>
                {
                    flow
                }
            };

            var result = bot.Conversation(inputMessage, chatId);

            var temp = (from buttons in result.KeyboardButtons from button in buttons select button.Text).ToList();

            var excepted = new List<string>
            {
                "Получить консультацию"
            };

            Assert.Multiple(() =>
            {
                Assert.AreEqual(botStartMessage, result.Text);
                CollectionAssert.AreEqual(excepted, temp);
            });
        }
    }
}