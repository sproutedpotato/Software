public class UserItem : FUserItem
{
    private bool dropped;
    private string name;
    private string kind;

    public virtual string GetItem()
    {
        return name;
    }
    public virtual void UseItem(string item)
    {
        Console.WriteLine($"You Use {item}.");
    }
    public virtual string GetItemKind() 
    {
        return kind;
    }
    public virtual bool GetDropped() 
    { 
        return dropped; 
    }
    public virtual void SetDropped(bool value) { }
}