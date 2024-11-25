class User
{
    private int hp { get; set; }
    private int mp { get; set; }
    private int score { get; set; }
    private int[,] myMap { get; set; }
    private string state { get; set; }
    
    private Position pos { get; set; }
    private Random rand = new Random();
    private static User user = null;
    private MapManager mapManager;

    private User() { 
        score = 0;
        mapManager = new MapManager();
        myMap = new int[mapManager.GetExitPos().y + 1, mapManager.GetExitPos().x + 1];
    }

    public static User GetInstance()
    {
        if (user == null) { user = new User(); }
        return user;
    }

    public int GetScore()
    {
        return score;
    }
    public void Attack()
    {
        Console.WriteLine("User Attacks Monster!");
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
        else
        {
            Console.WriteLine("Cant Walk!");
        }
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
    public void Defense() { }
    public void State() { }
    public void Death() { }
}

