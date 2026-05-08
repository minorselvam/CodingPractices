using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutAsyncAndWithoutAwait
{
    internal class WithoutAsyncAndWithoutAwaitHelper
    {
        ////Without Async and Await
        public string MethodAPI()
        {
            Task.Delay(5000);
            return "MethodAPI Result";
        }

        public string MethodDB()
        {
            Task.Delay(6000); // Simulate delay
            return "MethodDB Result";
        }
        public string MethodFileSystem()
        {
            // Simulate asynchronous operation (e.g., reading from a file)
            Task.Delay(8000); // Simulate delay
            return "MethodFileSystem Result";
        }        
    }
}
