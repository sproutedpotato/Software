public class FakeTreasure : Treasure
{
    private string name;
    private int score;
    private bool dropped;

    public FakeTreasure()
    {
        score = -100;
        name = "Fake Treasure";
        dropped = true;
    }

    public override string GetItem()
    {
        return name;
    }
    public override void UseItem(string item)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You Get {name}!! Your Score Has Decreased!!");
        Console.ResetColor();
    }
    public override string GetItemKind()
    {
        return name;
    }
    public override int GetScore()
    {
        return score;
    }
    public override bool GetDropped()
    {
        return dropped;
    }
    public override void SetDropped(bool value)
    {
        dropped = value;
    }
}
