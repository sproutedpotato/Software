public class ItemFactory
{
    public FUserItem CreateItem(string type)
    {
        if (type == "healingpotion")
        {
            return new HealingPotion();
        }
        else if (type == "manapotion")
        {
            return new ManaPotion();
        }
        else if (type == "clearpotion")
        {
            return new ClearPotion();
        }
        else if (type == "hiderobe")
        {
            return new HideRobe();
        }
        else if (type == "adropine")
        {
            return new Adropine();
        }
        else
        {
            return null;
        }
    }
}