using System;

namespace Infopulse
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextExecuter textExecuter = new TextExecuter();
            textExecuter.TextChecker();
            Console.ReadKey();
        }
    }
}
