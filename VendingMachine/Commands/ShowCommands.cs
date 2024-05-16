namespace VendingMachine
{
    class ShowCommands : ICommand
    {
        private string[] _commands;
        private IOutput _output;

        public ShowCommands(IOutput output, params string[] commands)
        {
            _commands = commands;
            _output = output;
        }

        public void Execute()
        {
            _output.WriteLine("Available commands:");
            foreach (string command in _commands)
            {
                _output.WriteLine(command);
            }
        }
    }
}