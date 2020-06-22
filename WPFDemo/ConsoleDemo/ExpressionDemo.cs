using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class ExpressionDemo
    {
        /// <summary>
        /// lambda生成sql
        /// </summary>
        /// <param name="lamda"></param>
        public static void ResolveLamda(Expression<Func<Person, bool>> expression)
        {
            var body = (BinaryExpression)expression.Body;
            var left = (MemberExpression)body.Left;
            var right = (ConstantExpression)body.Right;
            string format = string.Format("{0} {1} {2}",
                left.Member.Name, ResolveExpressionType(body.NodeType),
                right.Value);
            // expression.Body;
        }

        static string ResolveExpressionType(ExpressionType expressionType)
        {
            string type = string.Empty;
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    type = "=";
                    break;
                case ExpressionType.GreaterThan:
                    type = ">";
                    break;
                case ExpressionType.LessThan:
                    type = "<";
                    break;
                default:
                    break;
            }
            return type;
        }
    }

    public class Person
    { 
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
