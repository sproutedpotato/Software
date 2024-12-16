public class UserFactory
{
    public User CreateUser(string type)
    {
        if (type == "Player")
        {
            return new Player();
        }
        else
        {
            return null;
        }
    }
}