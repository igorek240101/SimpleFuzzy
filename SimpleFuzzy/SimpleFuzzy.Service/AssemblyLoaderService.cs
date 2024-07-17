using System.Reflection;

class AssemblyLoaderService
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