using System;

namespace BotCreators.Exceptions
{
    public class BotNotFoundedException : Exception
    {
        public BotNotFoundedException(string message)
            : base(message)
        {
        }

        public BotNotFoundedException()
        {
        }
    }
}