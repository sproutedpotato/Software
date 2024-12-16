class Program
{
    static void Main(string[] args)
    {
        string input;
        string[] inputs;
        string[,] map;
        bool condition;
        int score;

        List<string> inventory;
        Position userPos, prev;
        InitManager init;
        MapManager mapManager;
        GameManager gameManager;
        ItemFactory itemFactory;
        MonsterFactory monsterFactory;
        TreasureFactory treasureFactory;
        UserFactory userFactory;

        User user;
        FMonster slime, mushroom, ogre, devil, dragon;
        FTreasure trueTreasure, fakeTreasure;
        FUserItem healingpotion, manapotion, clearpotion, hiderobe, adropine;

        while (true)
        {
            Console.WriteLine("시작하려는 게임의 태그와 상태를 공백으로 구분해 입력해 주세요 : {tag status}")
; input = Console.ReadLine();
            inputs = input.Split();

            if (inputs.Length != 2) { Console.WriteLine("Error input. restart the program"); }
            else
            {
                if (string.Equals("true", inputs[1], StringComparison.OrdinalIgnoreCase) || string.Equals("false", inputs[1], StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Condition input Error. Please Retry : true or false");
                }
            }


        }
        Console.Clear();

        inputs[1] = inputs[1].ToLower();
        bool.TryParse(inputs[1], out condition);
        init = InitManager.GetInstance();
        init.DectetCondition(inputs[0], condition);

        mapManager = new MapManager();
        map = mapManager.GetMap();

        gameManager = new GameManager();
        monsterFactory = new MonsterFactory();
        itemFactory = new ItemFactory();
        treasureFactory = new TreasureFactory();
        userFactory = new UserFactory();

        healingpotion = itemFactory.CreateItem("healingpotion");
        manapotion = itemFactory.CreateItem("manapotion");
        clearpotion = itemFactory.CreateItem("clearpotion");
        hiderobe = itemFactory.CreateItem("hiderobe");
        adropine = itemFactory.CreateItem("adropine");

        fakeTreasure = treasureFactory.CreateTreasure("FakeTreasure");
        trueTreasure = treasureFactory.CreateTreasure("TrueTreasure");

        slime = monsterFactory.CreateMonster("slime");
        mushroom = monsterFactory.CreateMonster("mushroom");
        ogre = monsterFactory.CreateMonster("ogre");
        devil = monsterFactory.CreateMonster("devil");
        dragon = monsterFactory.CreateMonster("dragon");

        user = userFactory.CreateUser("Player");

        userPos = new Position(0, 0);
        while (true)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("You Can Move Through the Arrow Keys. (→, ←, ↑, ↓) OR Press Enter -> You Can Use Item.");
            Console.WriteLine($"Current Score is {user.GetScore()}");
            Console.WriteLine("----------------------------------------------------");
            mapManager.PrintMap(map, userPos);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            Console.Clear();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                gameManager.UseItem(user);
            }
            user.Walk(keyInfo, userPos, map);
            //Console.WriteLine($"Exit is {mapManager.GetExitPos().x} {mapManager.GetExitPos().y}");
            if (Position.ComparePosition(userPos, mapManager.GetExitPos()))
            {
                Console.Clear();
                //mapManager.PrintMap(map, userPos);
                inventory = gameManager.ReturnInventory();
                foreach (string item in inventory)
                {
                    if (item.Equals("Jelly"))
                    {
                        user.GetScore(1000, "+");
                    }
                    else if (item.Equals("Spores"))
                    {
                        user.GetScore(2000, "+");
                    }
                    else if (item.Equals("Mace"))
                    {
                        user.GetScore(3000, "+");
                    }
                    else if (item.Equals("Wing"))
                    {
                        user.GetScore(4000, "+");
                    }
                    else if (item.Equals("Scales"))
                    {
                        user.GetScore(5000, "+");
                    }
                }
                score = user.GetScore();

                Console.WriteLine($"Game Clear!! Your Score is {score}");
                break;
            }

            if (Position.ComparePosition(userPos, new Position(5, 0)))
            {
                if (!slime.Death())
                {
                    Console.Clear();
                    Console.WriteLine("You meet Slime! Battle Starts!");
                    gameManager.Battle(user, slime);
                }
                if (user.Death()) break;
            }

            if (Position.ComparePosition(userPos, new Position(5, 1)))
            {
                if (!mushroom.Death())
                {
                    Console.Clear();
                    Console.WriteLine("You meet Mushroom! Battle Starts!");
                    gameManager.Battle(user, mushroom);
                }
                if (user.Death()) break;
            }

            if (Position.ComparePosition(userPos, new Position(5, 2)))
            {
                if (!ogre.Death())
                {
                    Console.Clear();
                    Console.WriteLine("You meet Ogre! Battle Starts!");
                    gameManager.Battle(user, ogre);
                }
                if (user.Death()) break;
            }
            if (Position.ComparePosition(userPos, new Position(5, 3)))
            {
                if (!devil.Death())
                {
                    Console.Clear();
                    Console.WriteLine("You meet Devil! Battle Starts!");
                    gameManager.Battle(user, devil);
                }
                if (user.Death()) break;
            }

            if (Position.ComparePosition(userPos, new Position(5, 4)))
            {
                if (!dragon.Death())
                {
                    Console.Clear();
                    Console.WriteLine("You meet Dragon! Battle Starts!");
                    gameManager.Battle(user, dragon);
                }
                if (user.Death()) break;
            }

            if (Position.ComparePosition(userPos, new Position(2, 0)))
            {
                gameManager.UserGetTreasure(trueTreasure, user);
            }

            if (Position.ComparePosition(userPos, new Position(3, 0)))
            {
                gameManager.UserGetTreasure(fakeTreasure, user);
            }

            if (Position.ComparePosition(userPos, new Position(0, 1)))
            {
                gameManager.UserGetItem(healingpotion, user);
            }

            if (Position.ComparePosition(userPos, new Position(0, 2)))
            {
                gameManager.UserGetItem(manapotion, user);
            }

            if (Position.ComparePosition(userPos, new Position(0, 3)))
            {
                gameManager.UserGetItem(clearpotion, user);
            }

            if (Position.ComparePosition(userPos, new Position(0, 4)))
            {
                gameManager.UserGetItem(hiderobe, user);
            }

            if (Position.ComparePosition(userPos, new Position(0, 5)))
            {
                gameManager.UserGetItem(adropine, user);
            }

        }
        Console.WriteLine("Press Any Key To Close.");
        Console.ReadKey();
    }
}