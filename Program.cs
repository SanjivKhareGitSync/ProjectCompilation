using System;




namespace TheImpracticalNameSpace
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            AsyncSyncTaskThredAllInOne asyncSyncTaskThredAllInOne = new AsyncSyncTaskThredAllInOne();
            await asyncSyncTaskThredAllInOne.Run();
        }
    }
}
