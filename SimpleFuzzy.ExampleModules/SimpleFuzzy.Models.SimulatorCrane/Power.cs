using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Models.SimulatorCrane
{
    public class Power : IObjectSet
    {
        public bool Active { get; set; }

        public string Name => "Мощность";

        sbyte i = -100;

        public object Extraction() => i;

        public bool IsEnd() => i > 100;

        public void MoveNext() => i++;

        public void ToFirst() => i = 0;
    }
}
