using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static class ClassCalculator
    {
        private static Dictionary<string, Func<double, double, double>> Operations = new Dictionary<string, Func<double, double, double>>    
        {
            { "+", (x, y) => x + y },
            { "-", (x, y) => x - y },
            { "*", (x, y) => x * y },
            { "/", (x, y) => x / y }
        };

        public static double Operation(string op, double x, double y)
        {

            if (!Operations.ContainsKey(op))
                throw new ArgumentException($"Некорректный символ: {op}");
            if (op == "/" && y == 0)
                throw new ArgumentException("деление на 0 недопустимо");
            return Operations[op](x, y);
        }
    }
}
