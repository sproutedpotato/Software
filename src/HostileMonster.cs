public class HostileMonster : FMonster
{
    public virtual int Attack() {
        return -1;
    }
    public virtual int Skill() 
    {
        return 0;
    }
    public virtual void Defense(int damage) { }
    public virtual string State() 
    {
        return "";
    }
    public virtual string GetState() { return ""; }
    public virtual void SetState(string s) { }
    public virtual bool Death() {
        return true;
    }
    public virtual int GetHp(int num, string s) { return -1; }
    public virtual int GetScore()
    {
        return -1;
    }
    public virtual string MonsterKind() { return ""; }
    public virtual string GetDropItem() { return ""; }
}