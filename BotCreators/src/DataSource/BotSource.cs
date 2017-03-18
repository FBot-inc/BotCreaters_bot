using System.Collections.Generic;
using System.Linq;
using BotCreators.BotModule;
using BotCreators.BotModule.Flows.Inputs;
using BotCreators.Exceptions;

namespace BotCreators.DataSource
{
    public class BotSource
    {
        private static readonly List<Bot> Bots = new List<Bot>();

        static BotSource()
        {
            Bots.Add(
                item: CreateFBot()
            );
        }

        /*
         * Метод рассчитан на то, что позже боты будут загружаться из базы данных 
         * или других источников
         */
        public static Bot GetBotById(string botId)
        {
            var bot = Bots.FirstOrDefault(p => p.BotId.Equals(botId));

            if (bot == null)
            {
                throw new BotNotFoundedException("Bot with such ID not found");
            }

            return bot;
        }

        private static Bot CreateFBot()
        {
            var bot = new Bot("fbot");

            bot.StartInputs.Add(new SimpleInput("/start"));
            
            bot.Flows.Add(FlowSource.GetFlowById("how_are_you"));

            return bot;
        }
    }
}
