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

        public int Count => 201;

        public object this[int index] => index - 100;
    }
}
