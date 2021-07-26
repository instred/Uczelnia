using System;


namespace Z1
{
    class Z1
    {
        static void Main(string[] args)
        {
            SmtpFacade newFacade = new SmtpFacade("pass123");
            newFacade.Send("example@gmail.com", "example2@gmail.com", "Test Subj", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed...", null, "text/plain");
        }
    }
}