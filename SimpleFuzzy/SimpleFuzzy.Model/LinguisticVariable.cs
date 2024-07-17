using System;
using System.Collections.Generic;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Model;

public class LinguisticVariable
{
    public string? Name { get; set; } // Имя лингвистической переменной
    public IObjectSet BaseSet { get; set; } // Базовое множество
    public List<IMembershipFunction> Func = new List<IMembershipFunction>(); // Список термов
    public readonly bool IsRedact; // Возможность редактирования
    public LinguisticVariable(bool Redact) { IsRedact = Redact; }
    
    public void AddTerm(IMembershipFunction term) 
    {
        Type Type1 = BaseSet.Extraction().GetType(), Type2 = Func[0].GetType(); // Проверка типов данных
        if (Type1 != Type2) { throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают"); }
        else { Func.Add(term); }
    }
    public void DeleteTerm(IMembershipFunction term) => Func.Remove(term); 
    public List<double>[] Graphic()  // Создание массива списков для графика
    {
        List<double>[] list = new List<double>[Func.Count()];
        for (int i = 0; i < Func.Count(); i++)
        {
            BaseSet.ToFirst();
            while (!BaseSet.IsEnd())
            {
                list[i].Add(Func[i].MembershipFunction(BaseSet.Extraction()));
                BaseSet.MoveNext();
            }
        }
        return list;
    }
}
