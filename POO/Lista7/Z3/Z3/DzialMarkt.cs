using System;

namespace z3
{
    class DzialMarkt : Handler
    {
        protected override bool Request(string content)
        {
            Console.WriteLine("Wiadomość przekazana do działu marketingu. Dziękujemy!");
            return true;
        }
    }
}