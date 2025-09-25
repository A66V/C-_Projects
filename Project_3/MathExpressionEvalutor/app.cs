using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Csharp.MathExpressionEvalutor
{
    internal class app
    {

        internal void Run()
        {
            while(true)
            {
                var final_expression = new MathExpression();
                Console.Write("Enter your Expression :");
                string input_ = Console.ReadLine();
                final_expression = Expression_Parser.Parsing(input_);
                Console.WriteLine($" Left Side Operand = {final_expression.LeftSideOperand}, Operation = {final_expression.Operation} , Right Side Operand = {final_expression.RightSideOperand}");
                double res = Calcuate_Expression(final_expression);
                Console.WriteLine($"{final_expression.LeftSideOperand} {final_expression.Operation} {final_expression.RightSideOperand} = {res}");
            }
        }

        public double Calcuate_Expression(MathExpression m)
        {
            switch(m.Operation)
            {
                case MathOperation.Add:
                    return m.LeftSideOperand + m.RightSideOperand;
                case MathOperation.Subtract:
                    return m.LeftSideOperand - m.RightSideOperand;
                case MathOperation.Multiply:
                    return m.LeftSideOperand * m.RightSideOperand;
                case MathOperation.Divide:
                    return m.LeftSideOperand / m.RightSideOperand;
                case MathOperation.modulus:
                    return m.LeftSideOperand % m.RightSideOperand;
                case MathOperation.power:
                    return Math.Pow(m.LeftSideOperand, m.RightSideOperand);
                case MathOperation.sin:
                    return Math.Sin(m.RightSideOperand);
                case MathOperation.cos:
                    return Math.Cos(m.RightSideOperand);
                case MathOperation.tan:
                    return Math.Tan(m.RightSideOperand);
                default:
                    return 0.0;
            }
        }
    }
}

