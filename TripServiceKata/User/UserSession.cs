namespace TripServiceKata
{
    public class UserSession
    {
        private static readonly UserSession _userSession = new UserSession();

        private UserSession() { }

        public static UserSession GetInstance()
        {
            return _userSession;
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public User GetLoggedUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}
