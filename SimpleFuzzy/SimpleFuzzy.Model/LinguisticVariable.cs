using System;
using System.Collections.Generic;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Model;

public class LinguisticVariable
{
    public readonly string? Name; // Имя лингвистической переменной
    public readonly IObjectSet BaseSet; // Базовое множество
    public List<IMembershipFunction> Func = new List<IMembershipFunction>(); // Список термов
    
    public void AddTerm(IMembershipFunction term) // Добавление термов
    {
        Type Type1 = BaseSet.Extraction().GetType(), Type2 = Func[0].GetType(); // Проверка типов данных
        if (Type1 != Type2) { throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают"); }
        else { Func.Add(term); }
    }
    public void DeleteTerm(IMembershipFunction term) => Func.Remove(term); // Удаление термов
    public void Graphic(IObjectSet BaseSet, List<IMembershipFunction> func)  // Создание двумерного массива для графика
    {
        double[,] Array = new double[func.Count(), 100];
        for (int i = 0; i < func.Count(); i++)
            {
            for (int j = 0; !BaseSet.IsEnd(); j++)
            {
                Array[i,j] = func[i].MembershipFunction(BaseSet.Extraction());
                BaseSet.MoveNext();
            }
            BaseSet.ToFirst();
        }
    }
}
