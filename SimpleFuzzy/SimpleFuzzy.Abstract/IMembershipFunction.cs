using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Abstract
{
    public interface IMembershipFunction
    {
        double membershipFunc(object elem);
        Type InputType { get; }
    }
}
