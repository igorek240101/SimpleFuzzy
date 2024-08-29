using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Models.SimulatorCrane
{
    public class Angle : IObjectSet
    {
        public bool Active { get; set; }

        public string Name => "Угол";

        public sbyte i = -90;

        public object Extraction() => i;

        public bool IsEnd() => i > 90;

        public void MoveNext() => i++;

        public void ToFirst() => i = -90;
    }
}
