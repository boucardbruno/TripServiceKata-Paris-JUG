namespace TripServiceKata
{
    static class UserExtension
    {
        public static bool IsNotLogged(this User loggedUser)
        {
            return loggedUser == null;
        }
    }
}