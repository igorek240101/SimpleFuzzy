﻿using System;
using System.Collections.Generic;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Model;

public class LinguisticVariable
{
    public string name; // Имя лингвистической переменной
    public string Name 
    { 
        get { return name; }
        set { if (isRedact == true) { name = value; } } 
    }
    public IObjectSet baseSet; // Базовое множество
    public IObjectSet BaseSet
    {
        get { return baseSet; }
        set {
            if (isRedact == true)
                if (func.Count == 0) { baseSet = value; }
                else
                {
                    if (func[0].InputType == value.GetType()) { baseSet = value; }
                    else { throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают"); }
                }
        }
    }
    public List<IMembershipFunction> func = new List<IMembershipFunction>(); // Список термов
    public readonly bool isRedact; // Возможность редактирования
    public LinguisticVariable(bool isRedact) { this.isRedact = isRedact; }
    
    public void AddTerm(IMembershipFunction term) 
    {
        if (baseSet == null)
        {
            if (func.Count == 0) { func.Add(term); }
            else if (term.InputType == func[0].InputType) { func.Add(term); }
            else { throw new InvalidOperationException("Тип данных добавляемого терма не совпадает с уже имеющимися термами в списке"); }
        }
        else if (baseSet.Extraction().GetType() != term.InputType) { throw new InvalidOperationException("Выводимый и запрашиваемый тип данных не совпадают"); }
            else { func.Add(term); } // Проверка типов данных
    }

    public void Save()
    {
        // Здесь по видимому нужно будет реализовать логику сохранения данных,
        // пока этого нет, выбрасывается исключение
        throw new NotImplementedException("Метод Save() еще не реализован");
    }


    public void DeleteTerm(IMembershipFunction term) => func.Remove(term); 
    public List<double>[] Graphic()  // Создание массива списков для графика
    {
        List<double>[] list = new List<double>[func.Count()];
        for (int i = 0; i < func.Count(); i++)
        {
            list[i] = new List<double>(); // инициализация
            baseSet.ToFirst();
            while (!baseSet.IsEnd())
            {
                list[i].Add(func[i].MembershipFunction(baseSet.Extraction()));
                baseSet.MoveNext();
            }
        }
        return list;
    }
}