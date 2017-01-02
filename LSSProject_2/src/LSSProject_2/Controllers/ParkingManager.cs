using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Device.Location;

namespace LSSProject_2.Controllers
{
    public class ParkingManager: IParkingManager
    {
        private static readonly List<Parking> parkingList;

        static ParkingManager()
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("http://ucn-parking.herokuapp.com/places.json");
                parkingList = JsonConvert.DeserializeObject<List<Parking>>(json);
            }
        }
        public string GetParkingAddress(double latitude, double longitude, int range)
        {
            var p = getClosestParking(latitude, longitude, range);
            if (p != null)
                return p.name;
            return "";
        }

        private Parking getClosestParking(double latitude, double longitude, int range)
        {
            var result = new Parking();
            var min = (double) range * 1000;
            foreach (var p in parkingList)
            {
                var current = getDistance(latitude, longitude, p.latitude, p.longitude);
                if (current < min)
                {
                    min = current;
                    result = p;
                }
            }
            return result;
        }
        //NOTE: distance is in meters
        private double getDistance(double sLatitude, double sLongitude, double tLatitude, double tLongitude)
        {
            var sCoord = new GeoCoordinate(sLatitude, sLongitude);
            var tCoord = new GeoCoordinate(tLatitude, tLongitude);

            return sCoord.GetDistanceTo(tCoord);
        }
    }

    internal class Parking
    {
        public string name { get; set; }
        public int is_open { get; set; }
        public int is_payment_active { get; set; }
        public int status_park_place { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int max_count { get; set; }
        public int free_count { get; set; }
    }
}
