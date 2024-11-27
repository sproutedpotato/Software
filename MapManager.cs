class MapManager
{
    private string[,] map = 
        { { "┌", "┬", "┐" }, 
          { "├", "┼", "┤" }, 
          { "│", "│", "│"},
          { "└", "┴", "┘"} };

    private Position exit;

    public MapManager()
    {
        map = new string[,]
        { { "┌", "┬", "┐" },
          { "├", "┼", "┤" },
          { "│", "│", "│"},
          { "└", "┴", "┘"} };
        int row = map.GetLength(0);
        int col = map.GetLength(1);
        exit = new Position(col - 1, row - 1);
    }

    public Position GetExitPos()
    {
        return exit;
    }
    public string[,] GetMap()
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        string[,] mapCopy = new string[rows, cols];
        Array.Copy(map, mapCopy, map.Length);

        return mapCopy;
    }

    public void PrintMap(string[,] map, Position userPos)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                // 유저 위치 표시
                if (i == userPos.y && j == userPos.x)
                {
                    Console.Write("★ ");  // 유저의 위치를 '★'로 표시
                }
                else
                {
                    Console.Write(map[i, j] + " ");
                }
            }
            Console.WriteLine();  // 한 행 끝내고 줄바꿈
        }
    }
}
