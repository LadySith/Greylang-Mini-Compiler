using System;

namespace CompilerAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing If Command
            //Parser P = new Parser("if a + b then a := b + b else a := c + d");

            //Testing Assign Command
            //Parser P = new Parser("a := b + b");

            //Testing Let Command
            Parser P = new Parser("let a in b := a + b");

            Console.ReadLine();
        }

    }
}
