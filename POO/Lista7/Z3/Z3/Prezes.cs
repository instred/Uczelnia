using System;

namespace z3
{
    class Prezes : Handler
    {
        protected override bool Request(string content)
        {
            if (content[..8] == "Pochwała")
            {
                Console.WriteLine("Pochwała przekazana Panu Prezesowi :)");
                return true;
            }
            return false;
        }
    }
}