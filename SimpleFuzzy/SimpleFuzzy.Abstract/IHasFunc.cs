﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Abstract
{
    public interface IHasFunc : INameable
    {
        Type GetInputType {  get; }
        double GetResult(object input);
    }
}
