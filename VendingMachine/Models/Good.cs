using System;

namespace VendingMachine
{
    //DTO (Data transfer object)
    class Good
    {
        public Good(string name, int price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        protected internal void DecreaseCount(int amount)
        {
            if (amount < 0 || amount > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            Count -= amount;
        }
    }
}
