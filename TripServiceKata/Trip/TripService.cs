using System.Collections.Generic;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly TripDao _tripDao;
        // Parametrized Contructor
        public TripService() : this(new TripDao())
        {
        }

        public TripService(TripDao tripDao)
        {
            _tripDao = tripDao;
        }
        // Parametrized Method
        public List<Trip> GetTripsByUser(User user)
        {
            return GetTripsByUser(user, UserSession.GetInstance().GetLoggedUser());
        }
        public List<Trip> GetTripsByUser(User user, User loggedUser)
        {
            if (loggedUser.IsNotLogged()) throw new UserNotLoggedInException();

            var isFriend = user.IsFriendWith(loggedUser);

            return isFriend ?
                _tripDao.RetrieveTripsByUser(user) : new List<Trip>();
        }
    }
}
