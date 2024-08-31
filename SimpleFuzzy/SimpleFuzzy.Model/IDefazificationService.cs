using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Model
{
    public interface IDefazificationService
    {
        public enum Methods
        {
            Max,
            AvgMax,
            LinarLeft,
            LinarRight,
            CenterOfWight
        }

        object Defazification(LinguisticVariable output, List<object> input, Methods method, Rule.Inference inference, out List<ActiveRule> activeRules);

        List<object> DefazificationSimulator(List<object> input);


    }
}
