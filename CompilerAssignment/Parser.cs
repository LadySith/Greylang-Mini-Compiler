using System;
using System.Collections;
using static CompilerAssignment.AST;

namespace CompilerAssignment
{
    class Parser
    {
        // 1 - Identifier, 2 Operator, 3 LPar, 4 RPar, ??? 5 if, 6 then, 7 else, 8 becomes, 9 let, 10 in


        ArrayList TokenList;
        Token CurrentToken;
        int CurTokenPos;

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

        public Parser(String Sentence)
        {
            Scanner S = new Scanner(Sentence);

            TokenList = S.getTokens();
            CurTokenPos = -1;
            FetchNextToken();

            Command P = parseCommand();
            //Expression P = parseExpression();
        }

        void FetchNextToken()
        {
            CurTokenPos++;
            if (CurTokenPos < TokenList.Count)
                CurrentToken = (Token)TokenList[CurTokenPos];
            else
                CurrentToken = null;
        }

        void accept(int Type)
        {
            if (CurrentToken.matchesType(Type))
                FetchNextToken();
            else
                Console.WriteLine("Syntax Error in accept for token: " + CurrentToken.getSpelling());

        }

        void acceptIt()
        {
            FetchNextToken();
        }

        Expression parseExpression()
        {
            Expression ExpAST;
            PrimaryExpression P1 = parsePrimary();
            Operate O = parseOperator();
            PrimaryExpression P2 = parsePrimary();
            ExpAST = new Expression(P1, O, P2);
            return ExpAST;
        }


        PrimaryExpression parsePrimary()
        {
            PrimaryExpression PE;
            if (CurrentToken == null)
                return null;

            switch (CurrentToken.getType())
            {
                case Identifier:
                    Identifier I = parseIdentifier();
                    PE = new IdentifierPE(I);
                    break;
                case LPar:
                    acceptIt();
                    PE = new BracketsPE(parseExpression());
                    accept(RPar);
                    break;
                default:
                    Console.WriteLine("Syntax Error in Primary at token: " + CurrentToken.getSpelling());
                    PE = null;
                    break;
            }
            return PE;
        }

        Identifier parseIdentifier()
        {
            Identifier I = new Identifier(CurrentToken.getSpelling());
            accept(Identifier);
            return I;
        }

        Operate parseOperator()
        {
            Operate O = new Operate(CurrentToken.getSpelling());
            accept(Operator);
            return O;
        }

        //Create ParseCommand methods

        Declaration parseDeclaration()
        {
            //I'm not sure how to parse a declaration or if we need to?
            FetchNextToken();
            return null;
        }

        Command parseCommand()
        {
            Command C = null;
            if (CurrentToken == null)
                return null;

            switch (CurrentToken.getType())
            {
                case If:
                    accept(If);
                    Expression E = parseExpression();
                    accept(Then);
                    Command C1 = parseCommand();
                    accept(Else);
                    Command C2 = parseCommand();
                    C = new IfCommand(E, C1, C2);
                    break;

                case Identifier:
                    Identifier I = parseIdentifier();
                    accept(Becomes);
                    Expression E1 = parseExpression();
                    C = new AssignCommand(I, E1);
                    break;

                case Let:
                    accept(Let);
                    Declaration D = parseDeclaration();
                    accept(In);
                    Command C3 = parseCommand();
                    C = new letCommand(D, C3);
                    break;

                default:
                    Console.WriteLine("Syntax Error in Command at token: " + CurrentToken.getSpelling());
                    C = null;
                    break;

            }

            return C;
        }

        public ArrayList getParsedTokens()
        {
            
            return TokenList;
        }

    }
}
