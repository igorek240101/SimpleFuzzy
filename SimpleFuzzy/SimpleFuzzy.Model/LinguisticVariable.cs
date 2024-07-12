using System;
using System.Collections.Generic;
using SimpleFuzzy.SimpleModule;

namespace SimpleFuzzy.Abstract
{
    public class LinguisticVariable
    {
        public string Name { set { Name = Console.ReadLine(); } } // Имя лингвистической переменной

        public IObjectSet BaseSet; // Базовое множество
        public List<IMembershipFunction> Func = new List<IMembershipFunction>(); // Список термов
        public void AddTerm(MembershipFunc term) => Func.Add(term);  // Добавление термов
        public void DeleteTerm(MembershipFunc term) => Func.Remove(term); // Удаление термов

        public double Graphic(IObjectSet BaseSet, MembershipFunc func) => func.MembershipFunction(BaseSet.Extraction());
        //Значение данного терма в данной точке базового множества

        public void Compare() // Сравнение типов данных
        {
            Type Type1 = BaseSet.Extraction().GetType(), Type2 = Func[0].GetType();
            if (Type1 != Type2)
            {
                Console.WriteLine("The output and the requested data type do not match");
            }
        }
    }
}
