namespace SimpleFuzzy.Abstract
{
    public interface IObjectSet : IModulable
    {
        object Extraction();
        void MoveNext();
        void ToFirst();
        bool IsEnd();
    }
}
