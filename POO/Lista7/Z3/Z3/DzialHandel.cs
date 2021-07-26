using System;

namespace z3
{
    class DzialHandel : Handler
    {
        protected override bool Request(string content)
        {
            if (content[..10] == "Zamówienie")
            {
                Console.WriteLine("Złożone zamówienie przekazane do działu handlu.");
                return true;
            }
            return false;
        }
    }
}