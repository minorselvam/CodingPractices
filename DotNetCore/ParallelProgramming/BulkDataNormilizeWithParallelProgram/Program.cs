using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Buffers;
using ProviderNormalizationDemo;
using System.Xml.Linq;

namespace ProviderNormalizationDemo
{
    public class Provider
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create sample provider list
            var providers = new List<Provider>();
            for (int i = 0; i < 1000000; i++)
            {
                providers.Add(new Provider
                {
                    Name = "Dr. " + i,
                    Address = "Street " + i
                });
            }

            Console.WriteLine("Sequential Normalization...");
            var watchSequential = System.Diagnostics.Stopwatch.StartNew();
            SequentialNormalization(providers);
            watchSequential.Stop();
            Console.WriteLine($"Sequential completed in {watchSequential.ElapsedMilliseconds} ms");

            Console.WriteLine("Parallel Normalization...");
            var watchParallel = System.Diagnostics.Stopwatch.StartNew();
            ParallelNormalization(providers);
            watchParallel.Stop();
            Console.WriteLine($"Parallel completed in {watchParallel.ElapsedMilliseconds} ms");

            // Uncomment this block to test Span<T> + ArrayPool<T> optimization
            /*
            Console.WriteLine("Parallel Normalization with Span<T> + ArrayPool<T>...");
            var watchOptimized = System.Diagnostics.Stopwatch.StartNew();
            ParallelNormalizationOptimized(providers);
            watchOptimized.Stop();
            Console.WriteLine($"Optimized Parallel completed in {watchOptimized.ElapsedMilliseconds} ms");
            */
         }

        // Sequential version
        static void SequentialNormalization(List<Provider> providers)
        {
            foreach (var provider in providers)
            {
                provider.Name = NormalizeName(provider.Name);
                provider.Address = NormalizeAddress(provider.Address);
            }
        }

        // Parallel version using TPL
        static void ParallelNormalization(List<Provider> providers)
        {
            Parallel.ForEach(providers, provider =>
            {
                provider.Name = NormalizeName(provider.Name);
                provider.Address = NormalizeAddress(provider.Address);
            });
        }

        // Optimized Parallel version using Span<T> + ArrayPool<T>
        static void ParallelNormalizationOptimized(List<Provider> providers)
        {
            Parallel.ForEach(providers, provider =>
            {
                provider.Name = NormalizeNameOptimized(provider.Name);
                provider.Address = NormalizeAddress(provider.Address);
            });
        }

        // Simple normalization (allocates new strings each time)
        static string NormalizeName(string name)
        {
            return name.ToUpperInvariant();
        }

        static string NormalizeAddress(string address)
        {
            return address.Replace("Street", "St.");
        }

        // Optimized normalization using Span<T> + ArrayPool<T>
        static string NormalizeNameOptimized(string name)
        {
            // ArrayPool<T>: rents reusable buffers instead of allocating new arrays each time.
            // Span<T>: allows working directly on slices of memory without creating new copies.
            char[] buffer = ArrayPool<char>.Shared.Rent(name.Length);
            try
            {
                var span = new Span<char>(buffer, 0, name.Length);

                // Copy and transform directly into the rented buffer
                name.AsSpan().ToUpperInvariant(span);

                // Create final string from span
                return new string(span);
            }
            finally
            {
                // Return buffer to pool for reuse (avoids GC pressure)
                ArrayPool<char>.Shared.Return(buffer);
            }        
        }
    }
}