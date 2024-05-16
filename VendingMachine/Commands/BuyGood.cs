namespace VendingMachine
{
    class BuyGood : ICommand
    {
        private VendingMachine _machine;
        private IOrder _order;
        private IOutput _output;

        public BuyGood(VendingMachine machine, IOrder order, IOutput output)
        {
            _machine = machine;
            _order = order;
            _output = output;
        }

        public void Execute()
        {
            if (_machine.TryProcessOrder(_order))
            {
                _output.WriteLine($"Purchased {_order.GetTotalPrice()} worth of goods.");
                _output.WriteLine($"Purchased item: {_order.Good.Name}, Quantity: {_order.Count}");
            }
            else
            {
                _output.WriteLine("Failed to purchase goods. Check balance or availability.");
            }
        }
    }
}
