public class GameManager
{
    private int damage, userTurn, monsterTurn;
    private string name, userstate, behavior, monsterstate;
    private List<FUserItem> items = new List<FUserItem>();
    private static List<string> inventory = new List<string>();
    private string[] weapons = { "Sword", "Wand", "Bow" };
    private bool adropine = false;

    public void Battle(User user, FMonster monster)
    {
        userTurn = 0;
        monsterTurn = 0;     

        if (monster.MonsterKind().Equals("Hostile") && !user.GetState().Equals("Hide"))
        {
            MonsterDamageUser(user, monster);
            if (user.Death())
            {
                Console.WriteLine("GameOver...");
                
            }
        }

        while (true && !user.Death())
        {
            Console.WriteLine($"Your HP is : {user.GetHp()} And Mana is : {user.GetMp()}");
            Console.WriteLine($"Current User State is : {user.GetState()}");

            if (user.GetState().Equals("Hide"))
            {
                user.SetState("Normal");
            }

            userstate = user.GetState();
            monsterstate = monster.GetState();
            if (!(userstate.Equals("Freeze") || userstate.Equals("Stun") || userstate.Equals("Panic")))
            {
                while (true)
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("Choose Your Behavior : Attack : Item : Run : Weapon");
                    
                    behavior = Console.ReadLine();

                    Console.Clear();
                    if (behavior.Equals("Attack", StringComparison.OrdinalIgnoreCase) || behavior.Equals("Run", StringComparison.OrdinalIgnoreCase) || behavior.Equals("Item", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else if (behavior.Equals("Weapon", StringComparison.OrdinalIgnoreCase))
                    {
                        ChangeWeapon(user);
                    }
                    else Console.WriteLine("Wrong Input. Check Your Input");
                }

                if (string.Equals(behavior, "Attack", StringComparison.OrdinalIgnoreCase))
                {
                    UserDamageMonster(user, monster);
                }
                else if (string.Equals(behavior, "Run", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("You run.");
                    user.GetScore(100, "-");
                    user.SetState("Normal");
                    break;
                }
                else if (string.Equals(behavior, "Item", StringComparison.OrdinalIgnoreCase))
                {
                    UseItem(user);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Can't Do AnyThing!!");
                Console.ResetColor();
                userTurn = 0;
                monsterTurn = 0;
                user.SetState("Normal");
            }

            if (userstate.Equals("Poison"))
            {
                if (userTurn < 3)
                {
                    user.GetHp(5, "-");
                }
                else
                {
                    userTurn = 0;
                    user.SetState("Normal");
                }
            }
            else if (userstate.Equals("Burn")){
                if (userTurn < 5)
                {
                    user.GetHp(5, "-");
                }
                else
                {
                    userTurn = 0;
                    user.SetState("Normal");
                }
            }

            if (monsterstate.Equals("Poison"))
            {
                if (monsterTurn < 3)
                {
                    monster.GetHp(5, "-");
                }
                else
                {
                    monsterTurn = 0;
                    monster.SetState("Normal");
                }
            }
            else if (monsterstate.Equals("Burn"))
            {
                if (monsterTurn < 5)
                {
                    monster.GetHp(5, "-");
                }
                else
                {
                    monsterTurn = 0;
                    monster.SetState("Normal");
                }
            }
            else if (monsterstate.Equals("Blind"))
            {
                if (monsterTurn < 5)
                {
                    monster.GetHp(5, "-");
                }
                else
                {
                    monsterTurn = 0;
                    monster.SetState("Normal");
                }
            }

            if (monster.Death())
            {
                user.GetScore(monster.GetScore(), "+");
                MonsterDropItem(monster);
                adropine = false;
                user.SetState("Normal");
                break;
            }
            else
            {
                Console.WriteLine($"Current Monster's hp : {monster.GetHp()}");
            }

            MonsterDamageUser(user, monster);            

            if (user.Death())
            {
                Console.WriteLine("GameOver...");
                break;
            }

            if (!user.GetState().Equals("Normal")){
                userTurn += 1;
            }
            if (!monster.GetState().Equals("Normal"))
            {
                monsterTurn += 1;
            }
        }

        if (user.Death())
        {
            Console.WriteLine("You have been defeated by the Monster.");
        }
        else if (monster.Death())
        {
            Console.WriteLine("You have defeated the Monster!");
        }
    }
    public void UserGetTreasure(FTreasure treasure, User user)
    {
        Console.Clear();
        if (treasure.GetDropped())
        {
            name = treasure.GetItem();
            treasure.UseItem(name);
            user.GetScore(treasure.GetScore(), "+");
            treasure.SetDropped(false);
        }
    }
    public void UserGetItem(FUserItem item, User user)
    {
        if (item.GetDropped())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"User Get {item}!!");
            Console.ResetColor();
            items.Add(item);
            item.SetDropped(false);
        }
        
    }
    public void UserUseItem(int itemIndex, User user)
    {
        Console.Clear();

        FUserItem selectedItem = items[itemIndex];

        if (selectedItem.GetItem().Equals("HealingPotion", StringComparison.OrdinalIgnoreCase))
        {
            selectedItem.UseItem(selectedItem.GetItem());
            user.GetHp(50, "+");
            Console.WriteLine($"User Recover Hp, Current HP is {user.GetHp()}");
            items.Remove(selectedItem);
        }
        else if (selectedItem.GetItem().Equals("ManaPotion", StringComparison.OrdinalIgnoreCase))
        {
            selectedItem.UseItem(selectedItem.GetItem());
            user.GetMp(30, "+");
            Console.WriteLine($"User Recover Mp, Current MP is {user.GetMp()}");
            items.Remove(selectedItem);
        }
        else if (selectedItem.GetItem().Equals("ClearPotion", StringComparison.OrdinalIgnoreCase))
        {
            selectedItem.UseItem(selectedItem.GetItem());
            user.SetState("Normal");
            userTurn = 0;
            Console.WriteLine($"User Recover All States, Current State is {user.GetState()}");
            items.Remove(selectedItem);
        }
        else if (selectedItem.GetItem().Equals("HideRobe", StringComparison.OrdinalIgnoreCase))
        {
            selectedItem.UseItem(selectedItem.GetItem());
            user.SetState("Hide");
            Console.WriteLine($"User Hide Now..., Current State is {user.GetState()}");
            items.Remove(selectedItem);
        }
        else if (selectedItem.GetItem().Equals("Adropine", StringComparison.OrdinalIgnoreCase) && !adropine)
        {
            selectedItem.UseItem(selectedItem.GetItem());
            user.GetAtk(50, "+");
            Console.WriteLine($"User Attack Power Has Increased!!, Current Damage is {user.GetAtk()}");
            items.Remove(selectedItem);
            adropine = true;
        }
        else
        {
            Console.WriteLine("Wrong Input");
        }
    }
    public void UserDamageMonster(User user, FMonster monster)
    {
        damage = user.Skill();
        monsterstate = user.State();
        if (!monsterstate.Equals("Normal") && monster.GetState().Equals("Normal"))
        {
            monster.SetState(monsterstate);
        }
        monster.Defense(damage);
    }
    public void MonsterDamageUser(User user, FMonster monster)
    {
        damage = monster.Skill();
        userstate = monster.State();
        if (!userstate.Equals("Normal") && user.GetState().Equals("Normal"))
        {
            user.SetState(userstate);
        }
        user.Defense(damage);
    }
    public void ChangeWeapon(User user)
    {
        Console.Write("Your Weapon : ");
        foreach(var weapon in weapons)
        {
            if (!user.GetWeapon().Equals(weapon, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write($"{weapon} :");
            }
        }
        
        while(true){
            string userWeapon = Console.ReadLine();
            
            if (Array.Exists(weapons, element => string.Equals(element, userWeapon, StringComparison.OrdinalIgnoreCase)))
            {
                string formattedWeapon = char.ToUpper(userWeapon[0]) + userWeapon.Substring(1).ToLower();
                user.SetWeapon(formattedWeapon);
                break;
            }
            else
            {
                Console.WriteLine("Input Error. Check Your Input.");
            }
        }
    }
    public void MonsterDropItem(FMonster monster)
    {
        Console.WriteLine($"Monster Drop {monster.GetDropItem()}!! Your item has been added to your inventory.");
        inventory.Add(monster.GetDropItem());
    }
    public List<string> ReturnInventory()
    {
        return inventory;
    }
    public void UseItem(User user)
    {
        Console.WriteLine("Your Item : ");

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].GetItem()}");
        }

        Console.WriteLine("Select Item Number : OR RETURN");
        int itemIndex = -1;

        while (true)
        {
            string itemInput = Console.ReadLine();

            if (int.TryParse(itemInput, out itemIndex) && itemIndex >= 1 && itemIndex <= items.Count)
            {
                UserUseItem(itemIndex - 1, user);
                break;
            }
            else if (string.Equals(itemInput, "return", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("Input Error. Check Your Input.");
            }
        }
    }
}
