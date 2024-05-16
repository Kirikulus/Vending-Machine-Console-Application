namespace VendingMachine
{
    class Router
    {
        private VendingMachine _machine;
        private RouterState _state;
        private IOutput _output;

        public Router(VendingMachine machine, IOutput output)
        {
            _machine = machine;
            _state = new DefaultState(this);
            _output = output;
        }

        public ICommand CreateCommand(Request request)
        {
            switch (request.Command)
            {
                case "AddMoney":
                    if (request.IsIncorectValuesCount(1)) return null;
                    return new AddMoney(_machine, request.Values[0], _output);

                case "GetChange":
                    if (request.IsIncorectValuesCount(0)) return null;
                    return new GetChange(_machine, _output);

                case "BuyGood":
                    if (request.IsIncorectValuesCount(2)) return null;
                    return new BuyGood(_machine, _state.MakeOrder(request), _output);

                case "ShowCommands":
                    if (request.IsIncorectValuesCount(0)) return null;
                    return new ShowCommands(_output, "AddMoney", "GetChange", "BuyGood", "ShowCommands", "ShowGoods");

                case "Login":
                    if (request.IsIncorectValuesCount(0)) return null;
                    return new Login(this, _output);

                case "ShowGoods":
                    if (request.IsIncorectValuesCount(0)) return null;
                    return new ShowGoods(_machine, _output);

                default:
                    return null;
            }
        }

        public void Login()
        {
            _state = new AdminState(this);
        }

        public void Logout()
        {
            _state = new DefaultState(this);
        }

        abstract class RouterState
        {
            protected readonly Router Router;

            public RouterState(Router router)
            {
                Router = router;
            }

            public abstract IOrder MakeOrder(Request request);
        }

        class DefaultState : RouterState
        {
            public DefaultState(Router router) : base(router)
            {
            }

            public override IOrder MakeOrder(Request request)
            {
                return new Order(Router._machine.GetFromId(request.Values[0]), request.Values[1]);
            }
        }

        class AdminState : RouterState
        {
            public AdminState(Router router) : base(router)
            {
            }

            public override IOrder MakeOrder(Request request)
            {
                return new FreeOrder(Router._machine.GetFromId(request.Values[0]), request.Values[1]);
            }
        }
    }
}
