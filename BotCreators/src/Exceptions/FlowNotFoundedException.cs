using System;

namespace BotCreators.Exceptions
{
    public class FlowNotFoundedException : Exception
    {
        public FlowNotFoundedException(string message)
            : base(message)
        {
        }

        public FlowNotFoundedException()
        {
        }
    }
}
