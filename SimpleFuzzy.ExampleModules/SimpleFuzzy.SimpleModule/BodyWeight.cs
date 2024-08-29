using SimpleFuzzy.Abstract;

public class BodyWeight : IObjectSet
{
    public bool Active { get; set; }
    public string Name { get; } = "Масса тела";

    private double currentobject;

    public BodyWeight() => currentobject = 40;

    public object Extraction()
    {
        return currentobject;
    }

    public void MoveNext()
    {
        if (IsEnd())
        {
            throw new InvalidOperationException("Текущий элемент последний. Переход к следующему невозможен");
        }
        else
        {
            currentobject+=0.1;
        }
    }

    public void ToFirst() => currentobject = 40;

    public bool IsEnd() => currentobject > 130;
}