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
        protected TripService(TripDao tripDao)
        {
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            // Extract & Override Call
            User loggedUser = GetLoggedUser();
            if (loggedUser == null) throw new UserNotLoggedInException();

            bool isFriend = false;
            foreach (User friend in user.GetFriends())
            {
                if (friend.Equals(loggedUser))
                {
                    isFriend = true;
                    break;
                }
            }

            List<Trip> tripList = new List<Trip>();
            if (isFriend)
            {
                tripList = _tripDao.RetrieveTripsByUser(user);
            }
            return tripList;
        }

        protected virtual User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}
