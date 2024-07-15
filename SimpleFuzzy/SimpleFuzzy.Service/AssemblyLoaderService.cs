using System.Reflection;

class pluginLoader
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
            throw;
        }
        return ans;
    }
}