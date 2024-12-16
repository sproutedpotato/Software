public class Slime : FriendlyMonster
{
    private int hp { get; set; }
    private int mp { get; set; }
    private int damage { get; set; }
    private int score { get; set; }
    private string state { get; set; }
    private string dropitem { get; set; }
    private string[] states = { "Freeze" };
    private Random rand;
    private bool operateState { get; set;}
    private bool isDead;

    public Slime()
    {
        hp = 100;
        mp = 10;
        state = "Normal";
        damage = 10;
        rand = new Random();
        isDead = false;
        score = 1000;
        operateState = false;
        dropitem = "Jelly";
    }

    public override int Attack() 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Silme Attacks Player!");
        Console.ResetColor();
        if (mp < 10)
        {
            mp += 1;
        }
        return damage;
    }

    public override int Skill()
    {
        string[] skills = { "공격1", "공격2", "공격3" };
        int[] damages = { 15, 20, 25 };
        int[] use_mp = { 2, 3, 5 };

        int skill_index = rand.Next(0, skills.Length);

        if (use_mp[skill_index] > mp) { Attack(); }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Slime Uses {skills[skill_index]} to Player! ");
            Console.ResetColor();
            mp -= use_mp[skill_index];

            int setState = rand.Next(0, 5);
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
            Console.WriteLine($"Slime's State Changed!! : {state}");
            Console.ResetColor( );
        }

    }
    public override bool Death() {
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
        return "Friendly"; 
    }
    public override string GetDropItem()
    {
        return dropitem;
    }
}