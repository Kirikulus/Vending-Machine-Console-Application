namespace VendingMachine
{
    class GetChange : ICommand
    {
        private VendingMachine _machine;
        private IOutput _output;

        public GetChange(VendingMachine machine, IOutput output)
        {
            _machine = machine;
            _output = output;
        }

        public void Execute()
        {
            int change = _machine.Balance;
            _machine.DiscardBalance(change);
            _output.WriteLine($"Returned {change} as change. Current balance: {_machine.Balance}");
        }
    }
}