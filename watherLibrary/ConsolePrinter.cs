using System;
namespace weatherLibrary
{
    public class ConsolePrinter : IPrinter
    {
        private ConsoleColor color;

        public ConsolePrinter(ConsoleColor color)
        {
            this.color = color;
        }

        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }


        public void Print(string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
