using System;

namespace z3
{
    class Archiwum : Handler
    {
        protected override bool Request(string content)
        {
            Console.WriteLine("Zarchiwizowane.");
            return true;
        }
    }
}