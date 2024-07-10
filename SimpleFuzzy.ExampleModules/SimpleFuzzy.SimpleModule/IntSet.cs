using SimpleFuzzy.Abstract;

class IntSet : IObjSet<int>
{
    private List<int> objects;
    private int currentindex;

    public IntSet()
    {
        objects = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            objects.Add(i+1);
        }
        currentindex = 0;
    }

    public int Extraction()
    {
        return objects[currentindex];
    }

    public void MoveNext()
    {
        if (IsEnd())
        {
            throw new InvalidOperationException("Текущий элемент последний. Переход к следующему невозможен");
        }
        else
        {
            currentindex++;
        }
    }

    public void ToFirst()
    {
        currentindex = 0;
    }

    public bool IsEnd()
    {
        if (currentindex+1 == objects.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class SeriesDemo
{
    static void Main()
    {
        IntSet intSet = new IntSet();

        for (int i = 0;i < 100; i++)
        {
            Console.WriteLine(intSet.Extraction());
            intSet.MoveNext();
        }
        Console.WriteLine(intSet.Extraction());
    }
}


