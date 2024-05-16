using System;

namespace VendingMachine
{
    class VendingMachine
    {
        private Good[] _goods;
        public int Balance { get; private set; }
        public VendingMachine(int balance, params Good[] goods)
        {
            _goods = goods;
            Balance = balance;
        }
        public void AddBalance(int delta)
        {
            if (delta < 0) throw new ArgumentOutOfRangeException("delta");
            Balance += delta;
        }
        public void DiscardBalance(int delta)
        {
            if (delta < 0 || Balance < delta) throw new ArgumentOutOfRangeException("delta");
            Balance -= delta;
        }
        public bool IsOrderPossible(IOrder order)
        {
            return order.IsAvailable && order.GetTotalPrice() <= Balance;
        }
        public bool TryProcessOrder(IOrder order)
        {
            if (IsOrderPossible(order))
            {
                Balance -= order.GetTotalPrice();
                order.Ship();
                return true;
            }
            else return false;
        }
        public bool IsContains(int id)
        {
            return id >= 0 && id < _goods.Length;
        }
        public Good GetFromId(int id)
        {
            if (!IsContains(id)) throw new ArgumentOutOfRangeException("id");
            return _goods[id];
        }
        public void DisplayGoods(IOutput output)
        {
            output.WriteLine("Available goods:");
            for (int i = 0; i < _goods.Length; i++)
            {
                output.WriteLine($"{i}: {_goods[i].Name}, Price: {_goods[i].Price}, Available: {_goods[i].Count}");
            }
        }
    }
}
