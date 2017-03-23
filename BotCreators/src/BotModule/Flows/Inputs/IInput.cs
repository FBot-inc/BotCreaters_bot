namespace BotCreators.BotModule.Flows.Inputs
{
    public interface IInput
    {
        string GetTitle();

        bool IsBelong(string message);
    }
}
