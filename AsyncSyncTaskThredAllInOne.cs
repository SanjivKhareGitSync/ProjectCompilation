using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheImpracticalNameSpace
{
    internal class AsyncSyncTaskThredAllInOne
    {
        public AsyncSyncTaskThredAllInOne()
        {
        }

        public async Task<string> GetData_Async()
        {
            using (StreamWriter writer = new StreamWriter("E:\\Program Files\\FileWriteOutPutfolder\\output.txt"))
            {
                for (int i = 0; i < 500; i++)
                {
                    await writer.WriteLineAsync($"{DateTime.Now.TimeOfDay}");
                }
            }
            return "Data from async method";
        }
        public string GetData_Sync()
        {
            return "Data from sync method";
        }
        public async Task<bool> Run()
        {
                var dataAsync = GetData_Async();
                var dataSync = GetData_Sync();
                AppendString(dataSync);
                return true;
        }

        public void AppendString(string input)
        {
            using (StreamWriter writer2 = new StreamWriter(@"E:\Program Files\FileWriteOutPutfolder\output2.txt", false))
            {
                writer2.WriteLine(input +"---------"+ DateTime.Now.TimeOfDay);  // Or writer.Write(input);
            }
        }
    }
}
