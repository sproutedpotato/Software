public class MonsterFactory
{
    public FMonster CreateMonster(string type)
    {
        if(type == "slime")
        {
            return new Slime();
        }
        else if(type == "mushroom")
        {
            return new Mushroom();
        }
        else if(type == "ogre")
        {
            return new Ogre();
        }
        else if(type == "devil")
        {
            return new Devil();
        }
        else if(type == "dragon")
        {
            return new Dragon();
        }
        else
        {
            return null;
        }
    }
}