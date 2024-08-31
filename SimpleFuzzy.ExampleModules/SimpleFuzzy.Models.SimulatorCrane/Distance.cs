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

        public int Count => 20001;

        public object this[int index] => Math.Round(index * 0.01 - 100, 2);
    }
}
