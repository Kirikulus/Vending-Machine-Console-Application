namespace VendingMachine
{
    interface IOrder
    {
        bool IsAvailable { get; }
        int GetTotalPrice();
        void Ship();
        Good Good { get; }
        int Count { get; }
    }
}