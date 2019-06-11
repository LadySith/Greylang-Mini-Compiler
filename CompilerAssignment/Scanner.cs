using System;
using System.Collections;
using System.Text;

namespace CompilerAssignment
{
    class Scanner
    {
        const int Identifier = 1;
        const int Operator = 2;
        const int LPar = 3;
        const int RPar = 4;
        const int If = 5;
        const int Then = 6;
        const int Else = 7;
        const int Becomes = 8;
        const int Let = 9;
        const int In = 10;

        ArrayList TokenList = new ArrayList();
        String Sentence; int curPos;

        public Scanner(String S)
        {
            Sentence = S;
            BuildTokenList();
            curPos = 0;
        }

        public void DisplayTokens()
        {
            for (int x = 0; x <= TokenList.Count - 1; x++)
                ((Token)TokenList[x]).showSpelling();
        }

        public ArrayList getTokens()
        {
            return TokenList;
        }

        String BuildNextToken()
        {
            String Token = "";
            while (Sentence[curPos] == ' ') curPos++;
            while ((curPos < Sentence.Length) && (Sentence[curPos] != ' ')) //Tokens are groups of chars separated by spaces
            {
                Token = Token + Sentence[curPos];
                curPos++;
            }
            return Token;
        }

        int FindType(String Spelling)
        {
            if (Spelling.Equals("(")) return LPar;
            if (Spelling.Equals(")")) return RPar;
            if (Spelling.Equals("+")) return Operator;
            if (Spelling.Equals("-")) return Operator;
            if (Spelling.Equals("*")) return Operator;
            if (Spelling.Equals("/")) return Operator;
            if (Spelling.Equals("a")) return Identifier;
            if (Spelling.Equals("b")) return Identifier;
            if (Spelling.Equals("c")) return Identifier;
            if (Spelling.Equals("d")) return Identifier;
            if (Spelling.Equals("e")) return Identifier;
            if (Spelling.Equals("if")) return If;
            if (Spelling.Equals("then")) return Then;
            if (Spelling.Equals("else")) return Else;
            if (Spelling.Equals(":=")) return Becomes;
            if (Spelling.Equals("let")) return Let;
            if (Spelling.Equals("in")) return In;
            //Add other types here
            else
            {
                Console.WriteLine("Syntax Error: Invalid Type --> " + Spelling);
                return -1;
            };
        }

        void BuildTokenList()
        {
            Token newOne = null;
            while (curPos < Sentence.Length)
            {
                {
                    String nextToken = BuildNextToken();
                    newOne = new Token(nextToken, FindType(nextToken));
                }
                TokenList.Add(newOne);
            }
        }

    }
}
