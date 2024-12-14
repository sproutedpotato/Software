class InitManager
{
    private static InitManager init = null;

    private InitManager() { }
    public static InitManager GetInstance()
    {
        if (init == null) { init = new InitManager(); }
        return init;
    }

    public bool DectetCondition(string tag, bool condition) {
        if (!condition) { Console.WriteLine("game condition is bad. check your game condtion"); return false; } 
        else { Console.WriteLine($"{tag} game start..."); return true; }
    }
    
}