using System;
using System.Collections.Generic;
using BotCreators.BotModule.Flows.Conditions;

namespace BotCreators.BotModule.Flows.Responses
{
    public class SimpleResponse : IResponse
    {
        public string Text { get; }

        public SimpleResponse(string text)
        {
            Text = text ?? "";
        }

        public override bool Equals(object obj)
        {
            var response = obj as SimpleResponse;

            return response != null && Equals(response);
        }

        public override int GetHashCode()
        {
            return Text?.GetHashCode() ?? 0;
        }

        public bool Equals(SimpleResponse simpleResponse)
        {
            return simpleResponse != null && Text.Equals(simpleResponse.Text);
        }
    }
}
