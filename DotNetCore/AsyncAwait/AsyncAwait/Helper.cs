using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Helper
    {
         
        //With Async and Await
        public async Task<string> MethodAPI()
        {
            await Task.Delay(5000);
            return "MethodAPI Result";
        }

        public async Task<string> MethodDB()
        {
            await Task.Delay(2000); // Simulate delay
            return "MethodDB Result";
        }

        public async Task<string> MethodFileSystem()
        {
            // Simulate asynchronous operation (e.g., reading from a file)
            await Task.Delay(4000); // Simulate delay
            return "MethodFileSystem Result";
        }
         


        /*
        public string MethodAPI()
        {
            Task.Delay(1000);
            return "MethodAPI Result";
        }

        public string MethodDB()
        {
            Task.Delay(2000); // Simulate delay
            return "MethodDB Result";
        }
        public string MethodFileSystem()
        {
            // Simulate asynchronous operation (e.g., reading from a file)
            Task.Delay(4000); // Simulate delay
            return "MethodFileSystem Result";
        }
        */
    }
}
