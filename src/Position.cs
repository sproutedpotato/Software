public class Position
{
    public int x;
    public int y;
    
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static bool ComparePosition(Position pos1, Position pos2) 
    {
        if (pos2.x == pos1.x && pos1.y == pos2.y) return true;
        else return false;
    }
}