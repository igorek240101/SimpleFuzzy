namespace SimpleFuzzy.Abstract
{
    public interface IModulable
    {
        bool Active { get; set; }
        string Name { get; }
    }
}