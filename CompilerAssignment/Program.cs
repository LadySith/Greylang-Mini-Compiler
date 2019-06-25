using System;

namespace CompilerAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing If Command
            //Parser P = new Parser("if a + b then a := b * e else a := c + d");

            //Testing Assign Command
            //Parser P = new Parser("a := b + c");

            //Testing Let Command
            Parser P = new Parser("let a in b := a + c");

            //Testing nested commands
            //Parser P = new Parser("let b in if a + b then let a in b := a + b else a := c + d");

            Console.ReadLine();
        }

    }
}
