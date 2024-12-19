using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Abstract
{
    public class LinguisticVariableDto
    {
        public string Name { get; set; }
        public Type BaseSet { get; set; }
        public bool IsInput { get; set; }
    }
}
