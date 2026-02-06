using ProjectCompilation;
using System;


namespace TheImpracticalNameSpace
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //AsyncSyncTaskThredAllInOne asyncSyncTaskThredAllInOne = new AsyncSyncTaskThredAllInOne();
            //await asyncSyncTaskThredAllInOne.Run();

            IOStreamDream iOStreamDream = new IOStreamDream();
            string path = "E:\\desktop";
            iOStreamDream.DestinationDirectory = "E:\\GCFilesNew";
            //iOStreamDream.Run("E:\\all downloads\\old downloads\\pandas numpy django\\pandas numpy django", 4);
            iOStreamDream.Run(path, 7);
            //iOStreamDream.RunCollectFileNames("E:\\d");
        }
    }
}