namespace BotCreators.BotModule.Inputs
{
    public class Input : IInput
    {
        private string _pattern;

        public Input(string pattern)
        {
            _pattern = pattern;
        }

        public bool IsBelong(string message)
        {
            return _pattern != null && _pattern.Equals(message);
        }
    }
}
