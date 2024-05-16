namespace VendingMachine
{
    class Login : ICommand
    {
        private Router _router;
        private IOutput _output;

        public Login(Router router, IOutput output)
        {
            _router = router;
            _output = output;
        }

        public void Execute()
        {
            _router.Login();
            _output.WriteLine("Logged in as admin.");
        }
    }
}