public class Position
{
    public int x;
    public int y;
    
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int GetPosition_X()
    {
        return x;
    }

    public int GetPosition_Y()
    {
        return y;
    }

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
