namespace VendingMachine
{
    class Request
    {
        public Request(string command, int[] values)
        {
            Command = command;
            Values = values;
        }
        public string Command { get; set; }
        public int[] Values { get; set; }
        public bool IsIncorectValuesCount(int correct)
        {
            return correct != Values.Length;
        }
    }
}