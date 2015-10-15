using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata
{
    public static class TripDao
    {
        public static List<Trip.Trip> FindTripsByUser(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "TripDAO should not be invoked on an unit test.");
        }
    }
}
