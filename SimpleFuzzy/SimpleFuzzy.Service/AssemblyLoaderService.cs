using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService
    {
        public string getInfo(string filePath)
        {
            string ans = "";
            try
            {
                ans = Assembly.LoadFrom(filePath).FullName;
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Failed according to -> {exp.Message}\n");
            }
            return ans;
        }
    }
}
