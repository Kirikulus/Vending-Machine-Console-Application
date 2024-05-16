namespace VendingMachine
{
    class AddMoney : ICommand
    {
        private VendingMachine _machine;
        private int _money;
        private IOutput _output;

        public AddMoney(VendingMachine machine, int money, IOutput output)
        {
            _machine = machine;
            _money = money;
            _output = output;
        }

        public void Execute()
        {
            _machine.AddBalance(_money);
            _output.WriteLine($"Added {_money} to the balance. Current balance: {_machine.Balance}");
        }
    }
}