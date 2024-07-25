using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraView_Test_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("     You have an expression with 3 kinds of parenthesis ( ), [ ], { }.\n     Please write an algorithm that check the validaon of the expression. \n     Please write an algorithm that check the validaon of the expression\n     with addional parenthesis: ||.\n");
            Console.Write("     Pleas enter task expression:\n     acceptable chars are: |, (, {, [, ], }, )\n     any other symbols will be ignored:\n\n     ");
            char[] chars = { '|', '(', ')', '[', ']', '{', '}' };
            char[] task = Console.ReadLine().ToLower().Where(c => chars.Contains(c)).ToArray();
            Console.Write($"\n     Filtered input [{string.Join(", ", task)}]\n");

            Console.WriteLine(ValidateExpression(task) ? "\n     Expression Valid!!!" : "\n     Expression Invalid !!!");
            Console.Read();
        }

        private static bool ValidateExpression(char[] task) 
        {
            List<char> opened = new List<char>();

            char[] openers = { '(', '{', '[', '|' };

            int lastInd = -1;

            foreach (char c in task)
            {
                if ( openers.Contains(c))
                {
                    opened.Add(c);
                }
                else
                {
                    switch (c)
                    {
                        case ')':
                            lastInd = opened.LastIndexOf('(');
                            break;
                        case '}':
                            lastInd = opened.LastIndexOf('{');
                            break;
                        default:
                            lastInd = opened.LastIndexOf('[');
                            break;
                    }

                    if( lastInd < 0 || (opened.Count - lastInd) % 2 == 0 || opened.Skip(lastInd + 1).Any(x => x != '|'))
                    {
                        return false;
                    }

                    opened = opened.Take(lastInd).ToList();
                    lastInd = -1;
                }
            }
            
            return opened.Count % 2 == 0 || !opened.Any(x => x != '|');
        }
    }
}
