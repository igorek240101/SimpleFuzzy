using System.Reflection;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService
    {
        public string GetInfo(string filePath)
        {
            string ans = "";
            try
            {
                ans = Assembly.LoadFrom(filePath).FullName;
            }
            catch (Exception exp)
            {
                throw;
            }
            return ans;
        }
    }
}