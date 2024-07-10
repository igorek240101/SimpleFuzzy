using SimpleFuzzy.Abstract;

class AgeSet : IObjectSet
{
    private byte currentobject;

    public AgeSet()
    {
        currentobject = 0;
    }

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

    public void ToFirst()
    {
        currentobject = 0;
    }

    public bool IsEnd()
    {
        if (currentobject > 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}



