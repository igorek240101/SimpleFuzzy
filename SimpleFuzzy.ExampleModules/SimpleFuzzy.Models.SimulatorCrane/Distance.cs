using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Models.SimulatorCrane
{
    public class Distance : IObjectSet
    {
        public bool Active { get; set; }

        public string Name => "Расстояние";

        int i = -10000;

        public object Extraction() => i / 100.0;

        public bool IsEnd() => i > 10000;

        public void MoveNext() => i++;

        public void ToFirst() => i = -10000;
    }
}
