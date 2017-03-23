using System;

namespace BotCreators.BotModule.Flows.Inputs
{
    public class SimpleInput : IInput
    {
        public string Pattern { get; }

        public SimpleInput(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentException("Argument pattern cannot be null");
            }

            Pattern = pattern;
        }


        public string GetTitle()
        {
            return Pattern;
        }

        public bool IsBelong(string message)
        {
            return Pattern != null && Pattern.Equals(message);
        }


        public override bool Equals(object obj)
        {
            var input = obj as SimpleInput;

            return input != null && Equals(input);
        }

        public override int GetHashCode()
        {
            return Pattern?.GetHashCode() ?? 0;
        }

        public bool Equals(SimpleInput simpleInput)
        {
            return Pattern.Equals(simpleInput.Pattern);
        }
    }
}
