public interface FTreasure
{
    public string GetItem();
    void UseItem(string item);
    string GetItemKind();
    int GetScore();
    bool GetDropped();
    void SetDropped(bool dropped);
}