public class TrueTreasure : Treasure
{
    private int score;
    private string name;
    private string kind;
    private bool dropped;

    public TrueTreasure()
    {
        name = "True Treasure";
        kind = "Treasure";
        score = 1000;
        dropped = true;
    }

    public override string GetItem()
    {
        return name;
    }
    public override void UseItem(string item)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You Get {name}!! Score + 1000");
        Console.ResetColor();
    }
    public override string GetItemKind()
    {
        return kind;
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
