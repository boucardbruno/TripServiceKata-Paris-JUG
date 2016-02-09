using NFluent;
using NUnit.Framework;
using TripServiceKata;

namespace TripServiceTest
{
    public class TripServiceTests
    {
        [Test, ExpectedException(typeof(UserNotLoggedInException))]
        public void Should_raise_exception_when_no_user_logged()
        {
            var tripService = new TestableTripService {LoggedUser = NotLoggedUser};
            tripService.GetTripsByUser(GuestUser);
        }

        public User GuestUser { get; } = null;
        public User NotLoggedUser { get; } = null;
    }

    public class TestableTripService : TripService
    {
        protected override User GetLoggedUser()
        {
            return LoggedUser;
        }

        public User LoggedUser { get; set; }
    }
}
