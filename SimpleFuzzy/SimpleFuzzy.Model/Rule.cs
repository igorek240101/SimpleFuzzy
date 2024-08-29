using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleFuzzy.Model
{
    public class Rule
    {
        // НА НУЛЕВОЙ ПОЗИЦИИ ВСЕГДА ТЕРМ ВЫХОДНОЙ ПЕРЕМЕННОЙ
        private List<IMembershipFunction> terms = new List<IMembershipFunction>(); // Список термов 
        public double relevance = 1; // Степень заполняемости
        public bool IsActive { get; set; } // Автосвойство активности

        public Rule(int count) 
        {
            for (int i = 0; i < count; i++) { AddNullTerm(); }
        }
        public void AddNullTerm()
        {
            terms.Add(null);
        }
        public void DeleteTerm(int position)
        {
            terms.RemoveAt(position);
        }
        public void RedactTerm(IMembershipFunction func, int position)
        {
            terms[position] = func;
        }
    }
}
