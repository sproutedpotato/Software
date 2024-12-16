public interface User
{
    public int GetAtk(int num = 0, string s = "") { return -1; }
    public int GetHp(int num = 0, string s = "") { return -1; }
    public int GetMp(int num = 0, string s = "") { return -1; }
    public string GetWeapon() { return ""; }
    public void SetWeapon(string s) { }
    public int GetScore(int num = 0, string s = "") { return -1; }
    public int Attack() { return -1; }
    public int Skill() { return -1; }
    public void Walk(ConsoleKeyInfo key, Position userPos, string[,] map) { }
    public bool CheckWalk(string tile, ConsoleKeyInfo key) { return false; }
    public void Defense(int damage) { }
    public string State() { return ""; }
    public string GetState() { return ""; }
    public void SetState(string state) { }
    public bool Death() { return false; }
}
