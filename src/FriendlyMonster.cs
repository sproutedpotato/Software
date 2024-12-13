public class FriendlyMonster : FMonster
{

    public virtual int Attack() {
        return -1;
    }
    public virtual int Skill() 
    {
        return -1;
    }
    public virtual void Defense(int damage) { }
    public virtual string State() 
    {
        return "";
    }
    public virtual bool Death() {
        return false;
    }
    public virtual int GetHp(int num, string s) { return -1; }
    public virtual int GetScore() {
        return -1;
    }
    public virtual string GetState() { return "";  }
    public virtual void SetState(string s) { }
    public virtual string MonsterKind() { return ""; }
    public virtual string GetDropItem() { return ""; }
}

