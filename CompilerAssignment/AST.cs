using System;
using System.Collections.Generic;
using System.Text;

namespace CompilerAssignment
{
    abstract class AST
    {

    public class Expression : AST
    {
        public PrimaryExpression P1;
        public Operate O;
        public PrimaryExpression P2;

        public Expression(PrimaryExpression P1, Operate O, PrimaryExpression P2)
        {
            this.P1 = P1; this.O = O; this.P2 = P2;
        }
    }

    public class PrimaryExpression : AST
    {
    }

    public class IdentifierPE : PrimaryExpression
    {
        Terminal T;

        public IdentifierPE(Terminal T)
        {
            this.T = T;
        }
    }

    public class BracketsPE : PrimaryExpression
    {
        Expression E;

        public BracketsPE(Expression E)
        {
            this.E = E;
        }
    }

    public class Terminal : AST
    {
        String Spelling;

        public Terminal(String Spelling)
        {
            this.Spelling = Spelling;
        }
    }

    public class Identifier : Terminal
    {
        public Identifier(String Spelling) : base(Spelling)
        {
        }
    }

    public class Operate : Terminal
    {
        public Operate(String Spelling) : base(Spelling)
        {
        }
    }

        //Add Commands to AST
    public class Declaration : AST
        {
            //I'm not sure about how the Declaration should be implemented
        }

    public class Command : AST
        {

        }

    public class IfCommand : Command
        {
            public Expression E;
            public Command C1;
            public Command C2;

            public IfCommand(Expression E, Command C1, Command C2)
            {
                this.E = E; this.C1 = C1; this.C2 = C2;
            }
        }

    public class AssignCommand : Command
        {
            public Identifier I;
            public Expression E;

            public AssignCommand(Identifier I, Expression E)
            {
                this.I = I; this.E = E;
            }
        }

    public class letCommand : Command
        {
            public Declaration D;
            public Command C;

            public letCommand(Declaration D, Command C)
            {
                this.D = D; this.C = C;
            }
        }
}

}
