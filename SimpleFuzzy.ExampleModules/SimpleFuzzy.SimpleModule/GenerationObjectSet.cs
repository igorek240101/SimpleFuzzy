using SimpleFuzzy.Abstract;

public class GenerationObjectSet : IObjectSet
{
    private double initalvalue;
    private double currentvalue;
    private double limitvalue;
    private double step;


    public GenerationObjectSet (double initalvalue, double step, double limitvalue) 
    {
        if ((limitvalue - initalvalue) > step && limitvalue > initalvalue && step != 0) 
        {
            this.initalvalue = initalvalue;
            this.step = step;
            this.limitvalue = limitvalue;
        }
        else
        {
            throw new InvalidOperationException("Множество пусто или шаг множества некорректен");
        }
    }

    public object Extraction()
    {
        return currentvalue;
    }

    public void MoveNext()
    {
        if (IsEnd())
        {
            throw new InvalidOperationException("Текущий элемент последний. Переход к следующему невозможен");
        }
        else
        {
            currentvalue = currentvalue + step;
        }
    }

    public void ToFirst() => currentvalue = initalvalue;

    public bool IsEnd() => (currentvalue + step) > limitvalue;
}

