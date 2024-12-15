public class Player : User
{
    private int hp { get; set; }
    private int mp { get; set; }
    private int score { get; set; }
    private int damage { get; set; }
    private int[,] myMap { get; set; }
    private string state { get; set; }
    private string weapon;
    private string[] states = { "Burn", "Poison", "Blind" };

    private Random rand;
    private MapManager mapManager;
    private bool isDead, operateState;


    public Player() {
        hp = 300;
        mp = 50;
        score = 0;
        mapManager = new MapManager();
        myMap = new int[mapManager.GetExitPos().y + 1, mapManager.GetExitPos().x + 1];
        myMap[0, 0] = 1;
        damage = 40;
        state = "Normal";
        weapon = "Sword";
        rand = new Random();
        isDead = false;
    }

    public int GetAtk(int num = 0, string s = "")
    {
        if (s == "-") damage -= num;
        else if (s == "+") damage += num;
        return damage;
    }
    public int GetHp(int num = 0, string s = "")
    {
        if (s == "-") hp -= num;
        else if (s == "+") hp += num;
        return hp;
    }
    public int GetMp(int num = 0, string s = "")
    {
        if (s == "-") mp -= num;
        else if (s == "+") mp += num;
        return mp;
    }
    public string GetWeapon()
    {
        return weapon;
    }
    public void SetWeapon(string weapon)
    {
        this.weapon = weapon;
    }
    public int GetScore(int num = 0, string s = "")
    {
        if (s == "-") score -= num;
        else if (s == "+") score += num;
        return score;
    }
    public int Attack()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("User Attacks Monster!");
        Console.ResetColor();
        if (mp < 50)
        {
            mp += 5;
        }
        return damage;
    }
    public int Skill()
    {
        string[] skills = { "공격1", "공격2", "공격3" };
        int[] damages = { damage + 15, damage + 20, damage + 25 };
        int[] use_mp = { 15, 20, 25 };
        int skill_index;

        Console.WriteLine("Choose Your Attack! : 1. attack / 2. skill 1 / 3. skill 2 / 4. skill 3");
        while(true){
            skill_index = int.Parse(Console.ReadLine());
            if (!(skill_index <= skills.Length + 1 && skill_index >= 1))
            {
                Console.WriteLine("InputError. Check Your Input.");
            }
            else
            {
                break;
            }
        }

        if(skill_index == 1) { Attack(); return damage; }
        else
        {
            if (use_mp[skill_index - 2] > mp)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Your Mana Is Lack!");
                Console.ResetColor();
                Attack();
                return damage;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"User Uses {skills[skill_index - 2]} to Monster! ");
                Console.ResetColor();
                mp -= use_mp[skill_index - 2];

                int setState = rand.Next(0, 2);
                if (setState == 1) { operateState = true; }

                return damages[skill_index - 2];
            }
        }
    }
    public void Walk(ConsoleKeyInfo key, Position userPos, string[,] map)
    {
        if (key.Key == ConsoleKey.UpArrow && CheckWalk(map[userPos.y, userPos.x], key))
        {
            if (userPos.y > 0) userPos.y--;
            if (myMap[userPos.y, userPos.x] == 0)
            {
                score += 100;
                myMap[userPos.y, userPos.x] = 1;
            }
        }
        else if (key.Key == ConsoleKey.DownArrow && CheckWalk(map[userPos.y, userPos.x], key))
        {
            if (userPos.y < map.GetLength(0) - 1) userPos.y++;
            if (myMap[userPos.y, userPos.x] == 0)
            {
                score += 100;
                myMap[userPos.y, userPos.x] = 1;
            }
        }
        else if (key.Key == ConsoleKey.LeftArrow && CheckWalk(map[userPos.y, userPos.x], key))
        {
            if (userPos.x > 0) userPos.x--;
            if (myMap[userPos.y, userPos.x] == 0)
            {
                score += 100;
                myMap[userPos.y, userPos.x] = 1;
            }
        }
        else if (key.Key == ConsoleKey.RightArrow && CheckWalk(map[userPos.y, userPos.x], key))
        {
            if (userPos.x < map.GetLength(1) - 1) userPos.x++;
            if (myMap[userPos.y, userPos.x] == 0)
            {
                score += 100;
                myMap[userPos.y, userPos.x] = 1;
            }
        }
        //else
        //{
        //    Console.WriteLine("Cant Walk!");
        //}
    }
    private bool CheckWalk(string tile, ConsoleKeyInfo key)
    {
        string[] upTile = { "┌", "┬", "┐", "─" };
        string[] downTile = { "└", "┴", "┘", "─" };
        string[] leftTile = { "┌", "├", "└", "│" };
        string[] rightTile = { "┐", "┤", "┘", "│" };

        if (key.Key == ConsoleKey.UpArrow && !upTile.Contains(tile))
        {
            return true;
        }
        else if (key.Key == ConsoleKey.DownArrow && !downTile.Contains(tile)) 
        {
            return true;
        }
        else if (key.Key == ConsoleKey.LeftArrow && !leftTile.Contains(tile))
        {
            return true;
        }
        else if (key.Key == ConsoleKey.RightArrow && !rightTile.Contains(tile))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Defense(int damage) 
    {
        hp -= damage;
        if (hp <= 0)
        {
            isDead = true;
        }
    }
    public string State()
    {
        int state_index;
        if (operateState)
        {
            if (weapon.Equals("Sword")) state_index = 0;
            else if (weapon.Equals("Wand")) state_index = 1;
            else state_index = 2;

            string returnValue = states[state_index];
            operateState = false;
            return returnValue;
        }
        else
        {
            return "Normal";
        }
    }
    public string GetState()
    {
        return state;
    }
    public void SetState(string state)
    {
        this.state = state;
        if (!state.Equals("Normal"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"User's State Changed!! : {state}");
            Console.ResetColor();
        }

    }
    public bool Death() {
        return isDead;
    }
}

