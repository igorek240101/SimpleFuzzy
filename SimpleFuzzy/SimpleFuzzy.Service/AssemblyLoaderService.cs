using SimpleFuzzy.Abstract;
using System.Reflection;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService : IAssemblyLoaderService
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
