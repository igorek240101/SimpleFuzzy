using SimpleFuzzy.Abstract;

public class CalorieConsumptionPerDay : IObjectSet
{
    public bool Active { get; set; }
    public string Name { get; } = "Потребление калорий в день";

    private int currentobject;

    public CalorieConsumptionPerDay() => currentobject = 500;

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
            currentobject++;
        }
    }

    public void ToFirst() => currentobject = 500;

    public bool IsEnd() => currentobject > 5000;
}