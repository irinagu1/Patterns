using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    class InterpretatorContext
    {
        public Stack<string> Result;
        public InterpretatorContext()
            => Result = new Stack<string>();
    }

    abstract class AbstractExpression
    {
        public abstract void Interpret(InterpretatorContext context);
    }

    //арифм.операция, комманда
    abstract class TerminalExpression : AbstractExpression
    {
        public AbstractExpression Left { private get; set; }
        public AbstractExpression Right { private get; set; }

        public sealed override void Interpret(InterpretatorContext context)
        {
            Left.Interpret(context);
            string leftValue = context.Result.Pop();

            Right.Interpret(context);
            string rightValue = context.Result.Pop();

            DoInterpret(context, leftValue, rightValue);
        }
        protected abstract void DoInterpret
            (InterpretatorContext context, string leftVaue, string rightValue);
    }

    class EqualTerminalExpression : TerminalExpression
    {
        protected override void DoInterpret
            (InterpretatorContext context, string leftVaue, string rightValue)
        {
            var result = leftVaue == rightValue ? "true" : "false";
            context.Result.Push(result);
        }
    }
    class OrTerminalExpression : TerminalExpression
    {
        protected override void DoInterpret
            (InterpretatorContext context, string leftVaue, string rightValue)
        {
            var result =
                leftVaue == "true" || rightValue == "true" ? "true" : "false";
            context.Result.Push(result);
        }
    }


   
    class MyExpression : AbstractExpression
    {
        public string Value { private get; set; }
        public sealed override void Interpret(InterpretatorContext context)
        {
            context.Result.Push(Value);
        }
    }

    public static class InterpretatorClient
    {
        public static void Logic()
        {
            InterpretatorContext context = new();
            MyExpression input = new();

            var expression = new OrTerminalExpression 
            {
                Left = new EqualTerminalExpression
                {
                    Left = input,
                    Right = new MyExpression { Value = "4" }
                },
                Right = new EqualTerminalExpression
                {
                    Left = input,
                    Right = new MyExpression { Value = "четыре" }
                }
            };

            // Output: true 
            input.Value = "четыре";
            expression.Interpret(context);
            Console.WriteLine(context.Result.Pop());

            // Output: false 
            input.Value = "44";
            expression.Interpret(context);
            Console.WriteLine(context.Result.Pop());
        }
    }
}
