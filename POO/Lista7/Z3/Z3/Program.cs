using System;

namespace z3
{
    static class Program
    {
        private static void Main(string[] args)
        {
            // tworzymy nasz Handler, po czym podpinamy pozostałe, aby obsługiwać wszystkie typy wiadomości
            Handler handler = new Prezes();
            handler.HandlerAttach(new DzialPrawny());
            handler.HandlerAttach(new DzialHandel());
            handler.HandlerAttach(new DzialMarkt());

            handler.ChainOfResponsibility("Pochwała dla Pana Rafała za dobre zarządzanie");
            handler.ChainOfResponsibility("Zamówienie na 2 pary skarpet firmy Adidas");
            handler.ChainOfResponsibility("Promocja! Tylko dzisiaj 1+1 na wszystkie produkty!");
            handler.ChainOfResponsibility("Skarga na Pana Dawida. Bardzo niechlujnie wykonana robota.");
            handler.ChainOfResponsibility("Zamówienie na roboczą bluzę+t-shirt");
            handler.ChainOfResponsibility("Pochwała dla Pana Rafała, wypłaty się zgadzają :)");
            
            Console.ReadLine();
        }
    }
}