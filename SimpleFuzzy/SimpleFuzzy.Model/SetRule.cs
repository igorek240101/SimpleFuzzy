using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Model
{
    public class SetRule
    {
        // список словарей
        public List<Rule> rules; // список правил с одной и той же выходной переменной
        public List<LinguisticVariable> inputVariables; // список входных переменных
        public LinguisticVariable outVariable; // выходная переменная
        public SetRule(LinguisticVariable var)
        {
            outVariable = var;
            rules = new List<Rule>();
            inputVariables = new List<LinguisticVariable>();
        }

        public void AddInputVar(LinguisticVariable inputVar)
        {
            // Добавляем пустые термы
            foreach (var rule in rules) { rule.AddNullTerm(); }
            // Добавляем ЛП
            inputVariables.Add(inputVar);
        }

        public void DeleteInputVar(string name, int position)
        {
            int index = 0;
            // Удаляем ЛП из списка
            for (int i = 1; i < inputVariables.Count; i++)
            {
                if (inputVariables[i].Name == name)
                {
                    inputVariables.RemoveAt(i);
                    index = i;
                    break;
                }
            }
            // Удаляем термы из всех правил для удаляемой ЛП
            foreach (var rule in rules) { rule.DeleteTerm(position); }
        }
    }
}
