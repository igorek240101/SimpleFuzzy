using SimpleFuzzy.Abstract;

public class BodyWeight : IObjectSet
{
    public bool Active { get; set; }
    public string Name { get; } = "Масса тела";

    public int Count => 901;

    public object this[int index] => Math.Round(40 + index * 0.1, 1);
}