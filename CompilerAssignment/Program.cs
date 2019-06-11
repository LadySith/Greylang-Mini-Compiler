using System;

namespace CompilerAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser P = new Parser("a - ( b * c )");
            Console.ReadLine();
        }

    }
}
