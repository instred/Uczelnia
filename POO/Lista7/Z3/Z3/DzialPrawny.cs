using System;

namespace z3
{
    class DzialPrawny : Handler
    {
        protected override bool Request(string content)
        {
            if (content[..6] == "Skarga")
            {
                Console.WriteLine("Wiadomość ze skargą przekazana do działu prawnego.");
                return true;
            }
            return false;
        }
    }
}