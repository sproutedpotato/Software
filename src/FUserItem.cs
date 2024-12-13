public interface FUserItem
{
    string GetItem();
    void UseItem(string item);
    string GetItemKind();
    bool GetDropped();
    void SetDropped(bool dropped);
}