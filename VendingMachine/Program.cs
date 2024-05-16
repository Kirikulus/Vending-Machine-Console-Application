using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize goods
            Good[] goods = new Good[]
            {
                new Good("Coke", 25, 10),
                new Good("Pepsi", 35, 8),
                new Good("Water", 10, 20)
            };

            // Initialize vending machine with initial balance
            VendingMachine machine = new VendingMachine(100, goods);

            // Initialize output
            IOutput output = new ConsoleOutput();

            // Initialize router
            Router router = new Router(machine, output);

            // Initialize command input
            ICommandInput input = new ConsoleCommandInput(router);

            output.WriteLine("Welcome to the Vending Machine!");
            output.WriteLine("Type 'ShowCommands' to see available commands.");

            while (true)
            {
                output.WriteLine("\nEnter a command:");
                try
                {
                    ICommand command = input.GetCommand();
                    if (command != null)
                    {
                        command.Execute();
                    }
                    else
                    {
                        output.WriteLine("Invalid command or parameters.");
                    }
                }
                catch (FormatException ex)
                {
                    output.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    output.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}