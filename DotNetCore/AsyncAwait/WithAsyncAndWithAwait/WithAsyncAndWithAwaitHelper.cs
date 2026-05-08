using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithAsyncAndWithAwait
{
    internal class WithAsyncAndWithAwaitHelper
    {
        //With Async and Await
        public async Task<string> MethodAPI()
        {
            await Task.Delay(5000);
            return "MethodAPI Result";
        }

        public async Task<string> MethodDB()
        {
            await Task.Delay(6000); // Simulate delay
            return "MethodDB Result";
        }

        public async Task<string> MethodFileSystem()
        {
            // Simulate asynchronous operation (e.g., reading from a file)
            await Task.Delay(8000); // Simulate delay
            return "MethodFileSystem Result";
        }
    }
}
