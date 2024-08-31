using SimpleFuzzy.Abstract;

public class CalorieConsumptionPerDay : IObjectSet
{
    public bool Active { get; set; }
    public string Name { get; } = "Потребление калорий в день";

    public int Count => 4501;

    public object this[int index] => 500 + index;
}