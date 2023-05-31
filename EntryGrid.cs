public class EntryGrid
{
    public string City {get; set;}
    private double[] Values = new double[12];
    // public double[] ValueMonth 
    // {
    //     get { return Values; }
    //     set { Values = value; }
    // }

    // public double Value { get; set; }
    public EntryGrid(string _city, double _values, int _month)
    {
        City = _city;
        for (int i = 0; i < 12; i++)
        {
            if (i == _month)
                Values[i] = _values;
            else
                Values[i] = 0;
        }
        
    }
}