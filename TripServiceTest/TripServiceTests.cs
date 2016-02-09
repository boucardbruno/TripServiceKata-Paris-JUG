using System.Collections.Generic;
using NFluent;
using NSubstitute;
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

        [Test]
        public void 
            Should_return_no_trip_when_current_user_is_not_friend_with_logged_user()
        {
            var tripService = new TestableTripService { LoggedUser = LoggedUser };
            var tripsByUser = tripService.GetTripsByUser(NotFriendUser);
            Check.That(tripsByUser).IsEmpty();
        }

        [Test]
        public void 
            Should_return_trips_when_current_user_is_friend_with_logged_user()
        {
            User friendUser = new User();
            friendUser.AddFriend(LoggedUser);
            friendUser.AddTrip(Paris);
            friendUser.AddTrip(London);

            var tripDao = Substitute.For<TripDao>();
            tripDao.RetrieveTripsByUser(friendUser).Returns(new List<Trip> {Paris, London});

            var tripService = new TestableTripService(tripDao) { LoggedUser = LoggedUser };
            var tripsByUser = tripService.GetTripsByUser(friendUser);
            Check.That(tripsByUser).ContainsExactly(new List<Trip> {Paris, London});
        }

        public Trip London { get; } = new Trip();

        public Trip Paris { get; } = new Trip();

        public User NotFriendUser { get; } = new User();

        public User LoggedUser { get; } = new User();

        public User GuestUser { get; } = null;
        public User NotLoggedUser { get; } = null;
    }

    public class TestableTripService : TripService
    {
        public TestableTripService()
        {
            
        }
        public TestableTripService(TripDao tripDao):base(tripDao)
        {
        }

        protected override User GetLoggedUser()
        {
            return LoggedUser;
        }

        public User LoggedUser { get; set; }
    }
}
