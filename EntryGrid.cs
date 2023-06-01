public class EntryGrid
{
    public string City {get; set;}
    private double[] values = new double[12];
    public double[] Values 
    {
        get { return values; }
        set { values = value; }
    }

    public EntryGrid(string _city, double _values, int _month)
    {
        City = _city;
        for (int i = 0; i < 12; i++)
        {
            if (i == _month - 1)
                values[i] = _values;
            else
                values[i] = 0;
        }
        
    }
}