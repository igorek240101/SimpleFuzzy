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
        public static Dictionary<string, (bool, Func<IMembershipFunction, IMembershipFunction, object, double>)> operations = new Dictionary<string, (bool, Func<IMembershipFunction, IMembershipFunction, object, double>)>()
        {
            // Унарные операции
            {"Нечеткое дополнение", (true, (x, y, z) => 1 - x.MembershipFunction(z))},
            // Бинарные операции
            {"Нечеткое пересечение", (false, (x, y, z) => Math.Min(x.MembershipFunction(z), y.MembershipFunction(z)))}
        };

        public void UnloadHandler(object sender, EventArgs e)
        {
            string context = sender as string;
            if (Operand1 != null && Operand1.GetType().Assembly.FullName == context)
                Operand1 = null;
            if (Operand2 != null && Operand2.GetType().Assembly.FullName == context)
                Operand2 = null;
        }

        public Type InputType => Operand1.InputType;

        public bool Active { get => true; set => throw new NotImplementedException(); }

        public string Name { get; set; } = "";

        public double MembershipFunction(object elem)
        {
            if (Operand1 != null && (Operand2 != null || operations[Func].Item1) && Func != null)
                return operations[Func].Item2(Operand1, Operand2, elem);
            else
                return 0;
        }
    }
}
