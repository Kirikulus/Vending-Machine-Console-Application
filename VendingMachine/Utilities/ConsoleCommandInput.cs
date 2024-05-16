using System;

namespace VendingMachine
{
    class ConsoleCommandInput : ICommandInput
    {
        private Router _router;
        public ConsoleCommandInput(Router router)
        {
            _router = router;
        }
        public ICommand GetCommand()
        {
            string rawCommand = Console.ReadLine();
            Request request = ParseString(rawCommand);
            return _router.CreateCommand(request);
        }

        private Request ParseString(string input)
        {
            string[] terms = input.Split(' ');
            int[] values = new int[0];

            if (terms.Length > 1)
            {
                values = new int[terms.Length - 1];
                for (int i = 1; i < terms.Length; i++)
                {
                    if (int.TryParse(terms[i], out int result))
                    {
                        values[i - 1] = result;
                    }
                    else
                    {
                        throw new FormatException($"Invalid input format: {terms[i]} is not a valid number.");
                    }
                }
            }
            return new Request(terms[0], values);
        }
    }
}
