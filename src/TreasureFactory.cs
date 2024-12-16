public class TreasureFactory
{
    public FTreasure CreateTreasure(string type)
    {
        if (type == "TrueTreasure")
        {
            return new TrueTreasure();
        }
        else if (type == "FakeTreasure")
        {
            return new FakeTreasure();
        }
        else
        {
            return null;
        }
    }
}