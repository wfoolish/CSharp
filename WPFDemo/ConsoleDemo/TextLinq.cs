using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    /// <summary>
    /// 可扩展其他类型的linq支持
    /// 
    /// </summary>
    public class TextLinq
    {
        private Dictionary<string, string> _dic;
        public TextLinq()
        {
            _dic = new Dictionary<string, string>();
            _dic.Add("1001", "fadfafa");
            _dic.Add("1002", "fadf1002afa");
            _dic.Add("1003", "1003");
        }

        public string Search(Expression<Func<Param, bool>> expression)
        {
            var body = expression.Body;
            if (body is BinaryExpression)
            {
                if (body.NodeType != ExpressionType.Equal)
                    throw new Exception("只支持=和equals方法表达式");


                var left = (MemberExpression)((BinaryExpression)body).Left;
                var right = (ConstantExpression)((BinaryExpression)body).Right;
                if (_dic.ContainsKey(right.Value.ToString()))
                {
                    return _dic[right.Value.ToString()];
                }
            }
            else if (body is MethodCallExpression)
            {
                MethodCallExpression methodCallExpression = body as MethodCallExpression;
                if (methodCallExpression.Method.Name.Equals("equals", StringComparison.OrdinalIgnoreCase))
                {
                    string arg0 = methodCallExpression.Arguments[0].ToString();
                    if (_dic.ContainsKey(arg0.Trim('"')))
                    {
                        return _dic[arg0.Trim('"')];
                    }
                }
                else
                {
                    throw new Exception("只支持=和equals方法表达式");
                }
            }

            return string.Empty;
        }
    }

    public class Param
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
