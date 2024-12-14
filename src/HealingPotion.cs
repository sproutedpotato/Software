public class HealingPotion : UserItem
{ 
    private string name;
    private string kind;
    private bool dropped { get; set; }

    public HealingPotion()
    {
        name = "HealingPotion";
        kind = "UserItem";
        dropped = true;
}

    public override string GetItem()
    {
        return name;
    }
    public override void UseItem(string item)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You Use {item}.");
        Console.ResetColor();
    }
    public override string GetItemKind()
    {
        return kind;
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