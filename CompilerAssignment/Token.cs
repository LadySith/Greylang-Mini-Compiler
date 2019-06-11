using System;
using System.Collections.Generic;
using System.Text;

namespace CompilerAssignment
{
    class Token
    {
        String Spelling;
        int Type;        // 1 - Identifier, 2 Operator, 3 LPar, 4 RPar, ??? 5 if, 6 then, 7 else, 8 becomes, 9 let, 10 in
        public Token(String S, int T)
        {
            Spelling = S;
            Type = T;
        }

        public String getSpelling()
        {
            return Spelling;
        }

        public int getType()
        {
            return Type;
        }

        public void showSpelling()
        {
            Console.WriteLine(Spelling);
        }

        public Boolean matches(String other)
        {
            return (this.Spelling.Equals(other));
        }

        public Boolean matchesType(int T)
        {
            return (Type == T);
        }

    }
}
