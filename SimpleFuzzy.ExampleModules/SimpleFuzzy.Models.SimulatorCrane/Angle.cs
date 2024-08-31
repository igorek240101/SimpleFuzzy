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

        public int Count => 181;

        public object this[int index] => index - 90;
    }
}
