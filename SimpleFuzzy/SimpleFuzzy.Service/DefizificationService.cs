using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.Service
{
    public class DefizificationService : IDefazificationService
    {

        private IRepositoryService _repositoryService;
        
        public DefizificationService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public object Defazification(LinguisticVariable output, List<object> input, IDefazificationService.Methods method, Rule.Inference inference, out List<ActiveRule> activeRules)
        {
            switch (method)
            {
                case IDefazificationService.Methods.Max:
                    return MaxMethod(output, input, inference, out activeRules);
                case IDefazificationService.Methods.AvgMax:
                    return AvgMaxMethod(output, input, inference, out activeRules);
                case IDefazificationService.Methods.LinarLeft:
                    return LeftMethod(output, input, inference, out activeRules);
                case IDefazificationService.Methods.LinarRight:
                    return RightMethod(output, input, inference, out activeRules);
                case IDefazificationService.Methods.CenterOfWight:
                    return CenterOfWightMethod(output, input, inference, out activeRules);
                default:
                    {
                        activeRules = null;
                        return 0;
                    }
            }
        }

        private object MaxMethod(LinguisticVariable output, List<object> input, Rule.Inference inference, out List<ActiveRule> activeRules)
        {
            double max = 0;
            Rule maxRule = null;
            activeRules = new List<ActiveRule>();
            foreach (var rule in output.ListRules.rules)
            {
                (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                    values[i] = (output.ListRules.inputVariables[i], input[i]);
                double res = rule.CalcRule(values, inference);
                if (max < res)
                {
                    max = res;
                    maxRule = rule;
                }
                if (res != 0)
                {
                    var oldRule = activeRules.FirstOrDefault(x => x.function == rule[0]);
                    if (oldRule == null) activeRules.Add(new ActiveRule() { function = rule[0], values = res });
                    else oldRule.values = Math.Max(oldRule.values, res);
                }
            }
            if (maxRule != null)
            {
                object result = output.BaseSet[0];
                max = 0;
                for (int i = 0; i < output.BaseSet.Count; i++)
                {
                    object now = output.BaseSet[i];
                    double value = maxRule[0].MembershipFunction(now);
                    if (value > max)
                    {
                        result = now;
                        max = value;
                    }
                }
                return result;
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }

        private object AvgMaxMethod(LinguisticVariable output, List<object> input, Rule.Inference inference, out List<ActiveRule> activeRules)
        {
            double max = 0;
            List<(Rule, double)> maxRules = new List<(Rule, double)>();
            activeRules = new List<ActiveRule>();
            foreach (var rule in output.ListRules.rules)
            {
                (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                    values[i] = (output.ListRules.inputVariables[i], input[i]);
                double res = rule.CalcRule(values, inference);
                if (max < res)
                {
                    max = res;
                    maxRules.Clear();
                    maxRules.Add((rule, res));
                }
                else if (max == res && res != 0)
                    maxRules.Add((rule, res));
                if (res != 0)
                {
                    var oldRule = activeRules.FirstOrDefault(x => x.function == rule[0]);
                    if (oldRule == null) activeRules.Add(new ActiveRule() { function = rule[0], values = res });
                    else oldRule.values = Math.Max(oldRule.values, res);
                }
            }
            if (maxRules.Count > 0)
            {
                return output.BaseSet[maxRules.ConvertAll(x =>
                {
                    int result = 0;
                    max = 0;
                    for (int i = 0; i < output.BaseSet.Count; i++)
                    {
                        object now = output.BaseSet[i];
                        double value = x.Item1[0].MembershipFunction(now);
                        if (value > max)
                        {
                            result = i;
                            max = value;
                        }
                    }
                    return result;
                }).Aggregate((x, y) => x + y) / maxRules.Count];
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }

        private object LeftMethod(LinguisticVariable output, List<object> input, Rule.Inference inference, out List<ActiveRule> activeRules)
        {
            double max = 0;
            Rule maxRule = null;
            activeRules = new List<ActiveRule>();
            foreach (var rule in output.ListRules.rules)
            {
                (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                    values[i] = (output.ListRules.inputVariables[i], input[i]);
                double res = rule.CalcRule(values, inference);
                if (max < res)
                {
                    max = res;
                    maxRule = rule;
                }
                if (res != 0)
                {
                    var oldRule = activeRules.FirstOrDefault(x => x.function == rule[0]);
                    if (oldRule == null) activeRules.Add(new ActiveRule() { function = rule[0], values = res });
                    else oldRule.values = Math.Max(oldRule.values, res);
                }
            }
            if (maxRule != null)
            {
                double dist = 1;
                object result = output.BaseSet[0];
                double before = maxRule[0].MembershipFunction(output.BaseSet[0]);
                for (int i = 0; i < output.BaseSet.Count; i++)
                {
                    object now = output.BaseSet[i];
                    double value = maxRule[0].MembershipFunction(now);
                    if (before <= value && Math.Abs(value - max) < dist)
                    {
                        result = now;
                        dist = Math.Abs(value - max);
                    }
                    before = value;
                }
                return result;
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }

        private object RightMethod(LinguisticVariable output, List<object> input, Rule.Inference inference, out List<ActiveRule> activeRules)
        {
            double max = 0;
            Rule maxRule = null;
            activeRules = new List<ActiveRule>();
            foreach (var rule in output.ListRules.rules)
            {
                (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                    values[i] = (output.ListRules.inputVariables[i], input[i]);
                double res = rule.CalcRule(values, inference);
                if (max < res)
                {
                    max = res;
                    maxRule = rule;
                }
                if (res != 0)
                {
                    var oldRule = activeRules.FirstOrDefault(x => x.function == rule[0]);
                    if (oldRule == null) activeRules.Add(new ActiveRule() { function = rule[0], values = res });
                    else oldRule.values = Math.Max(oldRule.values, res);
                }
            }
            if (maxRule != null)
            {
                double dist = 1;
                object result = output.BaseSet[output.CountFunc - 1];
                double before = maxRule[0].MembershipFunction(output.BaseSet[0]);
                for (int i = output.BaseSet.Count - 1; i >= 0; i--)
                {
                    object now = output.BaseSet[i];
                    double value = maxRule[0].MembershipFunction(now);
                    if (before <= value && Math.Abs(value - max) < dist)
                    {
                        result = now;
                        dist = Math.Abs(value - max);
                    }
                    before = value;
                }
                return result;
            }
            else
            {
                return output.BaseSet[output.BaseSet.Count / 2];
            }
        }

        private object CenterOfWightMethod(LinguisticVariable output, List<object> input, Rule.Inference inference, out List<ActiveRule> activeRules)
        {
            double d;
            activeRules = new List<ActiveRule>();
            if (double.TryParse(output.BaseSet[0].ToString(), out d) && output.ListRules.rules.Count > 0)
            {
                double globalSum = 0;
                double count = 0;
                foreach (var rule in output.ListRules.rules)
                {
                    if (rule[0] != null)
                    {
                        (LinguisticVariable, object)[] values = new (LinguisticVariable, object)[input.Count];
                        for (int i = 0; i < output.ListRules.inputVariables.Count; i++)
                            values[i] = (output.ListRules.inputVariables[i], input[i]);
                        double res = rule.CalcRule(values, inference);
                        if (res != 0)
                        {
                            var oldRule = activeRules.FirstOrDefault(x => x.function == rule[0]);
                            if (oldRule == null) activeRules.Add(new ActiveRule() { function = rule[0], values = res });
                            else oldRule.values = Math.Max(oldRule.values, res);
                        }
                        double sum = 0;
                        for (int i = 1; i < output.BaseSet.Count; i++)
                        {
                            double right = double.Parse(output.BaseSet[i].ToString());
                            double left = double.Parse(output.BaseSet[i - 1].ToString());
                            sum += rule[0].MembershipFunction(output.BaseSet[i]) * (right - left) * right * res;
                            if (rule[0].MembershipFunction(output.BaseSet[i]) * (right - left) * right * res != 0)
                                count += rule[0].MembershipFunction(output.BaseSet[i]) * res * (right - left);
                        }
                        globalSum += sum;
                    }
                }
                return count > 0 ? globalSum / count : output.BaseSet[output.BaseSet.Count / 2];
            }
            else return output.BaseSet[output.BaseSet.Count / 2];
        }

        public List<object> DefazificationSimulator(List<object> input)
        {
            List<object> result = new List<object>();
            var simulator = _repositoryService.GetCollection<ISimulator>().FirstOrDefault(t => t.Active);
            if (simulator != null)
            {
                var simVariable = simulator.GetLinguisticVariables();
                for (int i = 0; i < simVariable.Count; i++)
                {
                    if (!simVariable[i].IsInput)
                    {
                        var output = _repositoryService.GetCollection<LinguisticVariable>().FirstOrDefault(t => !t.IsInput && t.Name == simVariable[i].Name);
                        if (output != null)
                        {
                            List<object> inputsForNowOutput = new List<object>();
                            foreach (var inputInput in output.ListRules.inputVariables) 
                            {
                                for (int j = 0; j < simVariable.Count; j++)
                                {
                                    if (inputInput.IsInput && simVariable[j].Name == inputInput.Name)
                                    {
                                        inputsForNowOutput.Add(input[j]);
                                        break;
                                    }
                                }
                            }
                            List<ActiveRule> activeRules;
                            result.Add(Defazification(output, inputsForNowOutput, IDefazificationService.Methods.CenterOfWight, Rule.Inference.Prod, out activeRules));
                        }
                    }
                }
            }
            return result;
        }
    }
}
