using System;
using System.Collections.Generic;
using System.Linq;

namespace BotCreators
{
    public class InputResponsePair
    {
        public UserInput Input { get; set; }
        public List<Response> Responses { get; set; }

        public InputResponsePair(UserInput input, List<Response> responses)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (responses == null)
            {
                throw new ArgumentNullException(nameof(responses));
            }

            Input = input;
            Responses = responses;
        }

        public override bool Equals(object obj)
        {
            var other = obj as InputResponsePair;

            if (other == null)
            {
                return false;
            }

            return Input.Equals(other.Input) && Responses.SequenceEqual(other.Responses);
        }
    }
}