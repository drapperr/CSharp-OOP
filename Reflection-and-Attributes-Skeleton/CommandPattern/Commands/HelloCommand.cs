using CommandPattern.Core.Contracts;

namespace CommandPattern.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string name = args[0];

            return $"Hello, {name}";
        }
    }
}
