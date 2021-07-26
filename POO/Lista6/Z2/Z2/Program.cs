using System;
using System.Collections.Generic;

namespace Z2
{
    class Program
    {
        static void Main(string[] args)
        {
            Context ctx = new Context();

            ctx.SetValue("x", false);
            ctx.SetValue("y", true);

            AbstractExpression exp = new ConjExpression(new NegExpression(
                new VarExpression("x")), new ConstExpression(false)); 
            bool value = exp.Interpret(ctx);
            Console.WriteLine(value.ToString());
            Console.ReadKey();
        }
    }

    public class Context
    {
        private Dictionary<string, bool> vars = new Dictionary<string, bool>();
        public bool GetValue(string variableName)
        {
            return vars[variableName];
        }
        public void SetValue(string variableName, bool value)
        {
            vars[variableName] = value;
        }
    }

    public abstract class AbstractExpression
    {
        public abstract bool Interpret(Context context);
    }

    public class ConstExpression : AbstractExpression
    {
        private readonly bool boo;
        public ConstExpression(bool value)
        {
            boo = value;
        }

        public override bool Interpret(Context context)
        {
            return boo;
        }
    }

    public class VarExpression : AbstractExpression
    {
        private string var_name;
        public VarExpression(string v)
        {
            var_name = v;
        }

        public override bool Interpret(Context context)
        {
            return context.GetValue(var_name);
        }
    }

    public class NegExpression : UnaryExpression
    {
        public NegExpression(AbstractExpression expr) : base(expr)
        {

        }

        public override bool Interpret(Context context)
        {
            return !expr.Interpret(context);
        }
    }

    public abstract class BinaryExpression : AbstractExpression
    {
        protected AbstractExpression expr1;
        protected AbstractExpression expr2;
        public BinaryExpression(AbstractExpression expr1, AbstractExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }
    }

    public class ConjExpression : BinaryExpression
    {
        public ConjExpression(AbstractExpression expr1, AbstractExpression expr2) : base(expr1, expr2)
        {

        }
        public override bool Interpret(Context context)
        {
            return expr1.Interpret(context) && expr2.Interpret(context);
        }
    }

    public class DisExpression : BinaryExpression
    {
        public DisExpression(AbstractExpression expr1, AbstractExpression expr2) : base(expr1, expr2)
        {

        }
        public override bool Interpret(Context context)
        {
            return expr1.Interpret(context) || expr2.Interpret(context);
        }
    }

    public abstract class UnaryExpression : AbstractExpression
    {
        protected AbstractExpression expr;
        public UnaryExpression(AbstractExpression expr)
        {
            this.expr = expr;
        }
    }
}