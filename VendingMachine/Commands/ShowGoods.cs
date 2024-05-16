namespace VendingMachine
{
    class ShowGoods : ICommand
    {
        private VendingMachine _machine;
        private IOutput _output;

        public ShowGoods(VendingMachine machine, IOutput output)
        {
            _machine = machine;
            _output = output;
        }

        public void Execute()
        {
            _machine.DisplayGoods(_output);
        }
    }
}