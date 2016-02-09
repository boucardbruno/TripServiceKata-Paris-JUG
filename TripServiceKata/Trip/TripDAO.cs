using System.Collections.Generic;

namespace TripServiceKata
{
    public class TripDao
    {
        // Introduce Instance Delegator
        public virtual List<Trip> RetrieveTripsByUser(User user)
        {
            return FindTripsByUser(user);
        }
        public static List<Trip> FindTripsByUser(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "TripDAO should not be invoked on an unit test.");
        }
    }
}
