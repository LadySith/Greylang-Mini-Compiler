using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace CompilerAssignment
{
    class Analyzer
    {
        ArrayList parsedTokens;
        string[] Declarations;

        int level;

        public Analyzer()
        {
            this.level = 0;
        }

        public void openScope()
        {
            level++;
        }

        public void closeScope()
        {
            level--;
        }

        public void Analyze()
        {
            if (Declarations.Length == 0)
            {
                Console.WriteLine("Program must have declared variables to execute");
            } else
            {
                if (!checkDeclarationsforDuplicates())
                {
                    Console.WriteLine("Variable has been declared twice");
                }
                
            }
        }

        public bool checkDeclarationsforDuplicates()
        {
            if (Declarations.Distinct().Count() != Declarations.Count())
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool checkTokenDeclarations()
        {
            bool idAllDeclared = true;

            for (int x = 0; x <= parsedTokens.Count - 1; x++)
            {
                if (((Token)(parsedTokens[x])).matchesType(9))
                {
                    openScope();
                }

                if (((Token)(parsedTokens[x])).matchesType(10))
                {
                    closeScope();
                }
            }
        

            return idAllDeclared;
            
        }




    }
}
