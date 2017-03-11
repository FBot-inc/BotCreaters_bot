using System;

namespace BotCreators.BotModule.Inputs
{
    public class Input : IInput
    {
        private readonly string _pattern;
        
        public Input(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentException("Argument pattern cannot be null");
            }

            _pattern = pattern;
        }

        public bool IsBelong(string message)
        {
            return _pattern != null && _pattern.Equals(message);
        }

        public override bool Equals(object obj)
        {
            var input = obj as Input;

            return input != null && Equals(input);
        }

        public override int GetHashCode()
        {
            return _pattern?.GetHashCode() ?? 0;
        }

        public bool Equals(Input input)
        {
            return _pattern.Equals(input._pattern);
        }
    }
}
