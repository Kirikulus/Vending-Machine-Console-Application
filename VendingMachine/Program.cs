using System;

namespace VendingMachine
{
    class Program
    {
        private static int balance = 0;
        private static int[] coinsQuantity = { 0, 0, 0, 0 }; // 1, 2, 5, 10
        private static int[] coinsValues = { 1, 2, 5, 10 };
        private static string[] names = { "Шоколадка", "Газировка" };
        private static int[] prices = { 70, 60 };
        private static int[] availableQuantity = { 5, 2 };
        private static PaymentType payment = PaymentType.Card;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplayBalance();
                DisplayGoods();
                string command = ReadCommand();
                ExecuteCommand(command);
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        private static void DisplayBalance()
        {
            Console.WriteLine($"Баланс: {balance} рублей");
        }

        private static void DisplayGoods()
        {
            Console.WriteLine("\nДоступные товары:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i}. {names[i]} - {prices[i]} рублей (в наличии: {availableQuantity[i]} шт.)");
            }
        }

        private static string ReadCommand()
        {
            Console.WriteLine("\nДоступные команды:");
            Console.WriteLine("1. AddMoney - Пополнить баланс");
            Console.WriteLine("2. GetChange - Получить сдачу");
            Console.WriteLine("3. BuyGood <id> <количество> - Купить товар");
            Console.WriteLine("Введите команду:");
            return Console.ReadLine();
        }

        private static void ExecuteCommand(string command)
        {
            if (command == "AddMoney")
            {
                AddMoney();
            }
            else if (command == "GetChange")
            {
                GetChange();
            }
            else if (command.StartsWith("BuyGood"))
            {
                BuyGood(command);
            }
            else
            {
                Console.WriteLine("Команда не определена");
            }
        }

        private static void AddMoney()
        {
            switch (payment)
            {
                case PaymentType.Coins:
                    for (int i = 0; i < coinsValues.Length; i++)
                    {
                        Console.WriteLine($"Сколько монет номиналом {coinsValues[i]} вы хотите внести?");
                        int count = ReadInt();
                        coinsQuantity[i] += count;
                        balance += count * coinsValues[i];
                    }
                    Console.WriteLine($"Баланс успешно пополнен. Текущий баланс: {balance} рублей");
                    break;
                case PaymentType.Card:
                    Console.WriteLine("Сколько снять с вашей карты?");
                    int balanceDelta = ReadInt();
                    balance += balanceDelta;
                    Console.WriteLine($"Баланс успешно пополнен на {balanceDelta} рублей. Текущий баланс: {balance} рублей");
                    break;
                default:
                    break;
            }
        }

        private static void GetChange()
        {
            Console.WriteLine($"Сдача: {balance} рублей");
            balance = 0;
            Console.WriteLine("Баланс обнулен");
        }

        private static void BuyGood(string command)
        {
            string[] rawData = command.Substring("BuyGood ".Length).Split(' ');
            if (rawData.Length != 2)
            {
                Console.WriteLine("Неправильные аргументы команды");
                return;
            }
            int id = 0;
            if (!MapParameter(rawData, out id, BuyGoodParameter.Id))
            {
                return;
            }
            int count = 0;
            if (!MapParameter(rawData, out count, BuyGoodParameter.Count))
            {
                return;
            }
            if (!Exist(id))
            {
                Console.WriteLine("Такого товара нет");
                return;
            }
            if (!IsAvailableInQuantity(id, count))
            {
                Console.WriteLine("Нет такого количества");
                return;
            }
            int totalPrice = GetTotalPrice(GetPrice(id), count);
            if (balance >= totalPrice)
            {
                balance -= totalPrice;
                availableQuantity[id] -= count;
                Console.WriteLine($"Вы купили {count} шт. {GetName(id)} за {totalPrice} рублей. Остаток на балансе: {balance} рублей");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на балансе");
            }
        }

        private static bool Exist(int id)
        {
            return id >= 0 && id < names.Length;
        }

        private static void ValidateId(int id)
        {
            if (!Exist(id))
            {
                throw new ArgumentOutOfRangeException("id");
            }
        }

        private static string GetName(int id)
        {
            ValidateId(id);
            return names[id];
        }

        private static int GetPrice(int id)
        {
            ValidateId(id);
            return prices[id];
        }

        private static int GetAvailableQuantity(int id)
        {
            ValidateId(id);
            return availableQuantity[id];
        }

        private static bool IsAvailableInQuantity(int id, int count)
        {
            return count > 0 && count <= GetAvailableQuantity(id);
        }

        private static int GetTotalPrice(int price, int count)
        {
            return price * count;
        }

        private static int ReadInt()
        {
            int result = 0;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Вы ввели не число! Повторите ввод:");
            }
            return result;
        }

        private static bool MapParameter(string[] rawParams, out int container, BuyGoodParameter parameter)
        {
            int index = (int)parameter;
            string name = Enum.GetName(typeof(BuyGoodParameter), parameter);
            if (!int.TryParse(rawParams[index], out container))
            {
                Console.WriteLine($"Ошибка в параметре {name}, он должен быть числом");
                return false;
            }
            return true;
        }
    }
    enum BuyGoodParameter
    {
        Id = 0,
        Count = 1
    }
    enum PaymentType
    {
        Coins,
        Card
    }
}