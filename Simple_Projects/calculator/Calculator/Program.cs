using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Calculator
{
    //create a small calculator (+ - * /)
    //All the numbers must be positive integers
    //the operation must be a valid char 
    //ask for 2 numbers 
    //ask to play again any case should be accepted (A or a)
    //Methods
    //Add subtract multiply divide
    //get positive integer
    //get valid operator
    //display result
    internal class Program
    {
        static void Main(string[] args)
        {
            string ope = GetValidOperator();

            if (ope == "+")
            {
                int result = Add();
                Console.WriteLine("Result: " + result);
            }
            else if (ope == "-")
            {
                int result = Minus();
                Console.WriteLine("Result: " + result);
            }
            else if (ope == "*")
            {
                int result = Multiply();
                Console.WriteLine("Result: " + result);

            }
            else if (ope == "/")
            {
                int result = Divide();
                Console.WriteLine("Result: " + result);
            }
        }
        static string GetValidOperator()
        {
            string userinput;
            userinput = null;
            bool valid;
            valid = false;
            while (!valid)
            {
                Console.Write("Operation? ");
                userinput = Console.ReadLine();
                if (userinput == "+")
                {
                    valid = true;
                }
                else if (userinput == "-")
                {
                    valid = true;
                }
                else if (userinput == "*")
                {
                    valid = true;
                }
                else if (userinput == "/")
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("Must insert a valid operator (+ - * /)");
                }
            }
            return userinput;
        }
        static int Add()
        {
            int answer;
            int input1, input2;
            input1 = GetNumberInput();
            input2 = GetNumberInput();
            answer = input1 + input2;
            return answer;

        }
        static int GetNumberInput()
        {
            int input;
            input = -1;
            bool valid;
            valid = false;
            while (!valid)
            {
                Console.Write("Input number: ");
                input = int.Parse(Console.ReadLine());
                if (input.ToString() == null)
                {
                    valid = false;
                    Console.WriteLine("Must write a valid number.");
                }
                else if (input > 0)
                {
                    valid = true;
                }
                else if (input < 0)
                {
                    valid = false;
                    Console.WriteLine("Must be a positive integer");
                }
            }
            return input;
        }
        static int Minus()
        {
            int answer;
            int input1, input2;
            input1 = GetNumberInput();
            input2 = GetNumberInput();
            answer = input1 - input2;
            return answer;
        }
        static int Multiply()
        {
            int answer;
            int input1, input2;
            input1 = GetNumberInput();
            input2 = GetNumberInput();
            answer = input1 * input2;
            return answer;
        }
        static int Divide()
        {
            int answer;
            int input1, input2;
            input1 = GetNumberInput();
            input2 = GetNumberInput();
            answer = input1 / input2;
            return answer;
        }
    }
}
