public class Treasure : FTreasure
{
    private int score;
    private string name;
    private bool dropped;

    public virtual string GetItem()
    {
        return name;
    }
    public virtual void UseItem(string item) { }

    public virtual string GetItemKind()
    {
        return name;
    }
    public virtual int GetScore()
    {
        return score;
    }
    public virtual bool GetDropped()
    {
        return dropped;
    }
    public virtual void SetDropped(bool dropped) { }
}
