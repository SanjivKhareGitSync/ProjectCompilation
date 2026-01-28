using System;




namespace TheImpracticalNameSpace
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AsyncSyncTaskThredAllInOne asyncSyncTaskThredAllInOne = new AsyncSyncTaskThredAllInOne();
            await asyncSyncTaskThredAllInOne.Run();
        }
    }
}
