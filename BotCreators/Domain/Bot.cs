using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCreators.Domain
{
    public class Bot
    {
        public Dictionary<string, Response> Responses = new Dictionary<string, Response>();

        public Response RetrievalResponse(string text, string chatId)
        {
            if (text == null || !Responses.ContainsKey(text))
            {
                var response = new Response()
                {
                    Text = "I don't know that i should answer"
                };

                return response;
            }

            return Responses[text];
        }

    }

    public class Response
    {
        public string Text { get; set; }
    }
}
