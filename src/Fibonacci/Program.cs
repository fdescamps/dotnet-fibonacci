using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Compute
    {
        public static int Fib(int arg)
        {
            if (arg <= 2)
            {
                return 1;
            }

            return Fib(arg - 2) + Fib(arg - 1);
        }
        public static IList<int> Execute(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            Console.WriteLine("System.Environment.ProcessorCount:  "+System.Environment.ProcessorCount);

            var results = new ConcurrentBag<int>();
            Parallel.ForEach(args, parallelOptions, (arg) =>
            {
                var result = Fib(int.Parse(arg));
                results.Add(result);
                Console.WriteLine("fibo result: "+result);
            });

            stopWatch.Stop();
            Console.WriteLine("Time elapsed "+stopWatch.Elapsed.TotalSeconds);

            return results.ToArray();
        }
    } 
}
