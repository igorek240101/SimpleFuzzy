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
        List<string> exceptionsMessages = new List<string>();
        public bool gotAnException()
        {
            return exceptionsMessages != null;
        }

        public void addException(string expMessage)
        {
            exceptionsMessages.Add(expMessage);
        }

        public string[] checkExceptions()
        {
            return exceptionsMessages.ToArray();
        }

        public string getInfo(string filePath)
        {
            string ans = "";
            try
            {
                ans = Assembly.LoadFrom(filePath).FullName;
            }
            catch (Exception exp)
            {
                addException(exp.Message);
            }
            return ans;
        }
    }
}
