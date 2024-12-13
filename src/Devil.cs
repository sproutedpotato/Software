public class Devil : HostileMonster
{
    private int hp { get; set; }
    private int mp { get; set; }
    private int damage { get; set; }
    private int score { get; set; }
    private string state { get; set; }
    private string dropitem { get; set; }
    private string[] states = { "Panic" };
    private Random rand;
    private bool operateState { get; set; }
    private bool isDead;

    public Devil()
    {
        hp = 170;
        mp = 30;
        state = "Normal";
        damage = 25;
        rand = new Random();
        isDead = false;
        score = 3000;
        operateState = false;
        dropitem = "Horn";
    }

    public override int Attack()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Devil Attacks Player!");
        Console.ResetColor();

        if (mp < 30)
        {
            mp += 5;
        }
        return damage;
    }

    public override int Skill()
    {
        string[] skills = { "공격1", "공격2", "공격3" };
        int[] damages = { 30, 35, 40 };
        int[] use_mp = { 7, 14, 21 };

        int skill_index = rand.Next(0, skills.Length);

        if (use_mp[skill_index] > mp) { Attack(); }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Devil Uses {skills[skill_index]} to Player! ");
            Console.ResetColor();
            mp -= use_mp[skill_index];

            int setState = rand.Next(0, 3);
            if (setState == 1) { operateState = true; }
        }

        return damages[skill_index];
    }
    public override void Defense(int damage)
    {
        hp -= damage;
        if (hp <= 0) isDead = true;
    }
    public override string State()
    {
        if (operateState)
        {
            string returnValue = states[rand.Next(0, states.Length)];
            operateState = false;
            return returnValue;
        }
        else
        {
            return "Normal";
        }
    }
    public override string GetState()
    {
        return state;
    }
    public override void SetState(string state)
    {
        this.state = state;
        if (!state.Equals("Normal"))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Devil's State Changed!! : {state}");
            Console.ResetColor();
        }

    }
    public override bool Death()
    {
        return isDead;
    }
    public override int GetHp(int num = 0, string s = "")
    {
        if (s == "-") hp -= num;
        else if (s == "+") hp += num;
        return hp;
    }
    public override int GetScore()
    {
        return score;
    }
    public override string MonsterKind()
    {
        return "Hostile";
    }
    public override string GetDropItem()
    {
        return dropitem;
    }
}
