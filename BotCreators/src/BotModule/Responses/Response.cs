using System;

namespace BotCreators.BotModule.Responses
{
    public class Response : IResponse
    {
        public string Text { get; }

        public Response(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("Pattern argument cannot be null");
            }

            Text = text;
        }

        public override bool Equals(object obj)
        {
            var response = obj as Response;

            if (response == null)
            {
                return false;
            }

            return Equals(response);
        }

        public override int GetHashCode()
        {
            return Text?.GetHashCode() ?? 0;
        }

        public bool Equals(Response response)
        {
            return response != null && Text.Equals(response.Text);
        }
    }
}
