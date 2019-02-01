using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infix_to_postfix
{
    class Program
    {
        static Boolean isOperand(char x)
            {
            return (x >= 'a' && x <= 'z') ||
                    (x >= 'A' && x <= 'Z');
        }

        // Get Infix for a given postfix 
        // expression 
        static String getInfix(string exp)
        {
           
            Stack s = new Stack();

            for (int i = 0; i < exp.Length; i++)
            {
                // Push operands 
                if (isOperand(exp[i]))
                {
                    s.Push(exp[i] + "");
                }

                // We assume that input is 
                // a valid postfix and expect 
                // an operator. 
                else
                {
                    string op1 = (string)s.Peek();
                    s.Pop();
                    string op2 = (string)s.Peek();
                    s.Pop();
                    s.Push("(" + op2 + exp[i] +
                            op1 + ")");
                }
            }

            // There must be a single element 
            // in stack now which is the required 
            // infix. 
            return (string)s.Peek();
        }

        // Driver code 
        public static void Main(string[] args)
        {
            string exp;
            Console.Write("enter Postfix Expression: ");
            exp = Console.ReadLine();
           // String exp = "abc*+";
            Console.WriteLine(getInfix(exp));
            Console.ReadLine();
        }
    }
  }

