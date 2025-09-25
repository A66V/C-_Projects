using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Csharp.MathExpressionEvalutor
{
    internal class Expression_Parser
    {
        /*
        Diff. test cases :
        5+6
        +5+6
        5 + 6 
        5             +                  6
        5             +6
        5+             6
        +56 = 11 
        +56+10 = 66 

         12345
         
         */
        public const string MathSymbols = "+*/%^";
        public static MathExpression Parsing(string input)
        {
            var expre = new MathExpression();
            bool isLeftExist = false;
            bool IsOperationExist = false;
            string token = "";
            for (int i = 0; i < input.Length; i++)
            {
                char current_char = input[i];

                if (char.IsDigit(current_char))
                {
                    token += current_char;
                    if (input.IndexOf(current_char) == input.Length-1)
                    {
                        expre.RightSideOperand = double.Parse(token);
                        break;
                    }
                    isLeftExist = true;
                }
                else if (MathSymbols.Contains(current_char))
                {
                    IsOperationExist = true;
                    expre.LeftSideOperand = double.Parse(token);
                    isLeftExist = true;
                    expre.Operation = Generate_Math_Operation(current_char.ToString());
                    token = "";
                }
                else if(current_char=='-')
                {
                    if((!isLeftExist) && (!IsOperationExist)) 
                    {
                        token += current_char;
                        isLeftExist = true;
                    }
                    else if((isLeftExist) && (!IsOperationExist))
                    {
                        expre.LeftSideOperand = double.Parse(token);
                        isLeftExist = true;
                        expre.Operation = MathOperation.Subtract;
                        IsOperationExist = true;
                        token = "";
                    }
                    else if((isLeftExist) && (IsOperationExist))
                    {
                        token += current_char;
                    }
                }
                else if (char.IsLetter(current_char))
                {
                    if((isLeftExist) && (!IsOperationExist))
                    {
                        expre.LeftSideOperand = double.Parse(token);
                        isLeftExist = true;
                        token = "";
                    }
                    token += current_char;
                    IsOperationExist = true;
                    if (char.IsDigit(input[i+1]) || (input[i+1] == ' '))
                    {
                        expre.Operation = Generate_Math_Operation(token);
                        token = "";
                    }
                }
                else if (current_char == ' ')
                { 
                    // Handling The cos , sin , tan
                    if((IsOperationExist) && (char.IsLetter(input[i+1])))
                    {
                        expre.Operation = Generate_Math_Operation(token);
                        token = "";
                    }
                }


            }
            return expre;
        }

        public static MathOperation Generate_Math_Operation(string token)
        {
            switch (token)
            {
                case "+":
                    return MathOperation.Add;
                case "*":
                    return MathOperation.Multiply;
                case "/":
                    return MathOperation.Divide;
                case "%":
                case "mod":
                    return MathOperation.modulus;
                case "^":
                case "pow":
                    return MathOperation.power;
                case "sin":
                    return MathOperation.sin;
                case "cos":
                    return MathOperation.cos;
                case "tan":
                    return MathOperation.tan;
                default:
                    return MathOperation.None;
            }

        }
    }
}
