using System.Collections.Generic;
using NFluent;
using NSubstitute;
using NUnit.Framework;
using TripServiceKata;

namespace TripServiceTest
{
    public class TripServiceTests
    {
        public Trip London { get; } = new Trip();

        public Trip Paris { get; } = new Trip();

        public User NotFriendUser { get; } = new User();

        public User LoggedUser { get; } = new User();

        public User GuestUser { get; } = null;
        public User NotLoggedUser { get; } = null;

        [Test, ExpectedException(typeof(UserNotLoggedInException))]
        public void Should_raise_exception_when_no_user_logged()
        {
            var tripService = new TripService();
            tripService.GetTripsByUser(GuestUser, NotLoggedUser);
        }

        [Test]
        public void 
            Should_return_no_trip_when_current_user_is_not_friend_with_logged_user()
        {
            var tripService = new TripService();
            var tripsByUser = tripService.GetTripsByUser(NotFriendUser, LoggedUser);
            Check.That(tripsByUser).IsEmpty();
        }

        [Test]
        public void 
            Should_return_trips_when_current_user_is_friend_with_logged_user()
        {
            var expectedTrips = new List<Trip> {Paris, London};
            var friendUser = BuildFriendUser(expectedTrips);
            var tripDao = MakeFakeTripDao(friendUser, expectedTrips);

            var tripService = new TripService(tripDao);
            var tripsByUser = tripService.GetTripsByUser(friendUser, LoggedUser);
            Check.That(tripsByUser).ContainsExactly(expectedTrips);
        }

        private static TripDao MakeFakeTripDao(User friendUser, List<Trip> expectedTrips)
        {
            var tripDao = Substitute.For<TripDao>();
            tripDao.RetrieveTripsByUser(friendUser).Returns(expectedTrips);
            return tripDao;
        }

        private User BuildFriendUser(List<Trip> expectedTrips)
        {
            User friendUser = new User();
            friendUser.AddFriend(LoggedUser);
            foreach (var trip in expectedTrips)
            {
                friendUser.AddTrip(trip);
            }
            return friendUser;
        }
    }
}
