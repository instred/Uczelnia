using System;

namespace z1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var invoker = new Invoker();
            Console.WriteLine("Start Invoker...");
            invoker.Run();
        }
    }
}