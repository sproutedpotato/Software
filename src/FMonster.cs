public interface FMonster
{
    int Attack();
    int Skill();
    void Defense(int damage);
    string State();
    bool Death();
    int GetHp(int num = 0, string s = "");
    int GetScore();
    string GetState();
    void SetState(string s);
    string MonsterKind();
    string GetDropItem();
}