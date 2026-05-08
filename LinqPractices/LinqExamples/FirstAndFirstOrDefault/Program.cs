using FirstAndFirstOrDefault.Data;
using FirstAndFirstOrDefault.Models;
using FirstAndFirstOrDefault.Services;

namespace FirstAndFirstOrDefault
{
    /*
     * 🔑 What Happens with This Data
        First → Returns the first match (Bob for >150). Throws if none.

        FirstOrDefault → Returns first match or null if none.

        Single → Throws if multiple matches (Test & Charlie both have Amount=300).

        SingleOrDefault → Returns null if none, but still throws if multiple matches.

        This setup makes it crystal clear how each method behaves when:

        No match exists (>500)

        One match exists (>150)

        Multiple matches exist (Amount=300)
    */

    internal class Program
    {
        static void Main()
        {
            using var context = new AppDbContext();

            // ✅ Seed in-memory data with multiple matches
            context.Orders.Add(new Order { Id = 1, CustomerName = "Alice", Amount = 100 });
            context.Orders.Add(new Order { Id = 2, CustomerName = "Bob", Amount = 200 });
            context.Orders.Add(new Order { Id = 3, CustomerName = "Test", Amount = 300 });
            context.Orders.Add(new Order { Id = 4, CustomerName = "Charlie", Amount = 300 });
            context.SaveChanges();

            var firstService = new FirstOrderService(context);
            var firstOrDefaultService = new FirstOrDefaultOrderService(context);
            var singleService = new SingleOrderService(context);
            var singleOrDefaultService = new SingleOrDefaultOrderService(context);

            Console.WriteLine("=== First() Demo ===");
            firstService.GetFirstOrderAboveAmount(150);   // Finds Bob
            firstService.GetFirstOrderAboveAmount(500);   // Throws, handled

            Console.WriteLine("\n=== FirstOrDefault() Demo ===");
            firstOrDefaultService.GetFirstOrDefaultOrderAboveAmount(150); // Finds Bob
            firstOrDefaultService.GetFirstOrDefaultOrderAboveAmount(500); // Returns null

            Console.WriteLine("\n=== Single() Demo ===");
            singleService.GetSingleOrderAboveAmount(200); // Throws because Test & Charlie both match

            Console.WriteLine("\n=== SingleOrDefault() Demo ===");
            singleOrDefaultService.GetSingleOrDefaultOrderAboveAmount(200); // Throws because multiple matches
            singleOrDefaultService.GetSingleOrDefaultOrderAboveAmount(500); // Returns null
        }
    }
}
