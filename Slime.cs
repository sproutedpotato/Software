class Slime : FriendlyMonster
{
    private int hp { get; set; }
    private int mp { get; set; }
    private string state { get; set; }
    private Position pos { get; set; }
    private Random rand = new Random();

    private Slime() { }

    protected int getSlime(string what)
    {
        if (what == "mp") { return mp; }
        else if (what == "hp") { return hp; }
        else { return -1; }

    }
    public void Attack() {
        Console.WriteLine("Silme Attacks Player!");
    }
    public void Walk(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.UpArrow) { pos.SetPosition(pos.x, pos.y + 1); }
        else if (key.Key == ConsoleKey.DownArrow) { pos.SetPosition(pos.x, pos.y - 1); }
        else if (key.Key == ConsoleKey.RightArrow) { pos.SetPosition(pos.x + 1, pos.y); }
        else { pos.SetPosition(pos.x - 1, pos.y); }
    }
    public void Skill()
    {
        string[] skills = { "공격1", "공격2", "공격3" };
        int[] use_mp = { 2, 3, 5 };

        int skill_index = rand.Next(0, skills.Length);

        if (use_mp[skill_index] < mp) { Attack(); mp += 1; }
        else
        {
            Console.WriteLine($"Slime Uses {skills[skill_index]} to Player! ");
            mp -= use_mp[skill_index];
        }
    }
    public void Defense() { }
    public void State() { }
    public void Death() { }
}