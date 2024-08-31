namespace SimpleFuzzy.Abstract
{
    public interface IFilesPathsNamesValidator
    {
        bool IsValidFileName(string fileName);
        bool IsValidDirectoryName(string directoryName);
    }
}
