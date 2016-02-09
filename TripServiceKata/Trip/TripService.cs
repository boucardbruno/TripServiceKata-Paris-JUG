using System.Collections.Generic;

namespace TripServiceKata
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            User loggedUser = UserSession.GetInstance().GetLoggedUser();
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
                tripList = TripDao.FindTripsByUser(user);
            }
            return tripList;
        }
    }
}
