using System.Collections.Generic;

namespace TripServiceKata
{
    public class User
    {
        private readonly List<Trip> _trips = new List<Trip>();
        private readonly List<User> _friends = new List<User>();

        public List<User> GetFriends()
        {
            return _friends;
        } 

        public void AddFriend(User user)
        {
            _friends.Add(user);
        }

        public void AddTrip(Trip trip)
        {
            _trips.Add(trip);
        }

        public List<Trip> Trips()
        {
            return _trips;
        } 
    }
}
