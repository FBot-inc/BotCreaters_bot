using System;
using System.Collections.Generic;

namespace BotCreators.Domain
{
    public class Bot
    {
        public Dictionary<string, Response> Responses = new Dictionary<string, Response>();

        public Response RetrievalResponse(string text, long chatId)
        {
            if (text == null)
            {
                throw new ArgumentException("Parameters can't be null");
            }

            Response response = null;

            if (response == null)
            {
                return new Response
                {
                    Text = "I don't know that i must answer"
                };
            }

            return response;
        }
    }
}
