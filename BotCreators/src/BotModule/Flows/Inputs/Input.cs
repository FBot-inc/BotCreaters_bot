using System;

namespace BotCreators.BotModule.Flows.Inputs
{
    public class Input : IInput
    {
        public string Pattern { get; }

        public Input(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentException("Argument pattern cannot be null");
            }

            Pattern = pattern;
        }

        public bool IsBelong(string message)
        {
            return Pattern != null && Pattern.Equals(message);
        }

        public override bool Equals(object obj)
        {
            var input = obj as Input;

            return input != null && Equals(input);
        }

        public override int GetHashCode()
        {
            return Pattern?.GetHashCode() ?? 0;
        }

        public bool Equals(Input input)
        {
            return Pattern.Equals(input.Pattern);
        }
    }
}
