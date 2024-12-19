namespace SimpleFuzzy.Abstract
{
    public interface IObjectSet : IModulable
    {

        object this[int index] { get; }
        int Count { get; }
    }
}
