using SimpleFuzzy.Abstract;
using System.Collections.Generic;
using System;

namespace SimpleFuzzy.Model
{
    public class FuzzyOperation : IMembershipFunction
    {
        public IMembershipFunction Operand1 { get; set; }
        public IMembershipFunction Operand2 { get; set; }
        public string Func { get; set; }
        public double p { get; set; }
        public static Dictionary<string, (bool, Func<IMembershipFunction, IMembershipFunction, object, double, double>)> operations = new Dictionary<string, (bool, Func<IMembershipFunction, IMembershipFunction, object, double, double>)>()
        {
            // Унарные операции
            {"Нечеткое дополнение", (true, (x, y, z, p) => 1 - x.MembershipFunction(z))},
            {"Концентрация", (true, (x, y, z, p) => Math.Pow(x.MembershipFunction(z), 2))},
            {"Расширение", (true, (x, y, z, p) => Math.Pow(x.MembershipFunction(z), 0.5))},
            {"Контраст", (true, (x, y, z, p) => x.MembershipFunction(z) < 0.5 ? 2 * Math.Pow(x.MembershipFunction(z), 2) : 1 - 2 * Math.Pow(1 - x.MembershipFunction(z), 2))},
            // Бинарные операции
            {"Нечеткое \"И\"", (false, (x, y, z, p) => p * Math.Min(x.MembershipFunction(z), y.MembershipFunction(z)) + 0.5 * (1 - p) * (x.MembershipFunction(z) + y.MembershipFunction(z)) / 2 )},
            {"Нечеткое \"ИЛИ\"", (false, (x, y, z, p) => p * Math.Max(x.MembershipFunction(z), y.MembershipFunction(z)) + 0.5 * (1 - p) * (x.MembershipFunction(z) + y.MembershipFunction(z)) / 2 )},
            {"Гамма - оператор", (false, (x, y, z, p) => Math.Pow(x.MembershipFunction(z) * y.MembershipFunction(z), 1 - p) * Math.Pow(1 - (1 - x.MembershipFunction(z)) * (1 - y.MembershipFunction(z)), p))},
            {"Min-Max \"И\"", (false, (x, y, z, p) => Math.Min(x.MembershipFunction(z), y.MembershipFunction(z)))},
            {"Min-Max \"ИЛИ\"", (false, (x, y, z, p) => Math.Max(x.MembershipFunction(z), y.MembershipFunction(z)))},
            {"\"Усиленное\" произведение", (false, (x, y, z, p) => (Math.Max(x.MembershipFunction(z), y.MembershipFunction(z)) == 1) ? Math.Min(x.MembershipFunction(z), y.MembershipFunction(z)) : 0)},
            {"\"Усиленная\" сумма", (false, (x, y, z, p) => (Math.Min(x.MembershipFunction(z), y.MembershipFunction(z)) == 0) ? Math.Max(x.MembershipFunction(z), y.MembershipFunction(z)) : 1)},
            {"Лукашевич \"И\"", (false, (x, y, z, p) => Math.Max(0, x.MembershipFunction(z) + y.MembershipFunction(z) - 1)) },
            {"Лукашевич \"ИЛИ\"", (false, (x, y, z, p) => Math.Min(1, x.MembershipFunction(z) + y.MembershipFunction(z))) },
            {"Эйнштейновское \"И\"", (false, (x, y, z, p) => (x.MembershipFunction(z) * y.MembershipFunction(z)) / (2 - (x.MembershipFunction(z) + y.MembershipFunction(z) - x.MembershipFunction(z) * y.MembershipFunction(z))))},
            {"Эйнштейновское \"ИЛИ\"", (false, (x, y, z, p) => (x.MembershipFunction(z) + y.MembershipFunction(z)) / (1 + x.MembershipFunction(z) * y.MembershipFunction(z)))},
            {"Алгебраическое \"И\"", (false, (x, y, z, p) => x.MembershipFunction(z) * y.MembershipFunction(z))},
            {"Алгебраическое \"ИЛИ\"", (false, (x, y, z, p) => x.MembershipFunction(z) + y.MembershipFunction(z) - x.MembershipFunction(z) * y.MembershipFunction(z))},
            {"Хамахеровское \"И\"", (false, (x, y, z, p) => x.MembershipFunction(z) * y.MembershipFunction(z) / (x.MembershipFunction(z) + y.MembershipFunction(z) - x.MembershipFunction(z) * y.MembershipFunction(z)))},
            {"Хамахеровское \"ИЛИ\"", (false, (x, y, z, p) => (x.MembershipFunction(z) + y.MembershipFunction(z)) - 2 * x.MembershipFunction(z) * y.MembershipFunction(z) / (1 - x.MembershipFunction(z) * y.MembershipFunction(z)))},
            {"T - оператор Ягера", (false, (x, y, z, p) => 1 - Math.Min(Math.Pow(Math.Truncate(Math.Pow(1 - x.MembershipFunction(z), p) + Math.Pow(1 - y.MembershipFunction(z), p)), 1 / p), 1))},
            {"S - оператор Ягера", (false, (x, y, z, p) => Math.Min(Math.Pow(Math.Pow(x.MembershipFunction(z), p) + Math.Pow(y.MembershipFunction(z), p), 1 / p), 1))},
        };

        public void UnloadHandler(object sender, EventArgs e)
        {
            string context = sender as string;
            if (Operand1 != null && Operand1.GetType().Assembly.FullName == context)
                Operand1 = null;
            if (Operand2 != null && Operand2.GetType().Assembly.FullName == context)
                Operand2 = null;
        }
        public FuzzyOperation()
        {
            Active = true;
        }
        public Type InputType => Operand1.InputType;

        public bool Active { get; set; }

        public string Name { get; set; } = "";

        public double MembershipFunction(object elem)
        {
            if (Operand1 != null && (Operand2 != null || operations[Func].Item1) && Func != null)
                return operations[Func].Item2(Operand1, Operand2, elem, p);
            else
                return 0;
        }
    }
}