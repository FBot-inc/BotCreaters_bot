namespace BotCreators
{
    public class UserInput
    {
        public string Pattern { get; }

        public UserInput(string pattern)
        {
            Pattern = pattern ?? "";
        }

        public bool Compare(string message)
        {
            return Pattern.Equals(message);
        }

        public override bool Equals(object obj)
        {
            var other = obj as UserInput;

            return other != null && Pattern.Equals(other.Pattern);
        }

        protected bool Equals(UserInput other)
        {
            return string.Equals(Pattern, other.Pattern);
        }

        public override int GetHashCode()
        {
            return Pattern?.GetHashCode() ?? 0;
        }
    }
}