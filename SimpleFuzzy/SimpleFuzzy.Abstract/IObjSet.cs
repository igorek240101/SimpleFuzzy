namespace SimpleFuzzy.Abstract
{
    public interface IObjectSet
    {
        object Extraction();
        void MoveNext();
        void ToFirst();
        bool IsEnd();
    }
}
