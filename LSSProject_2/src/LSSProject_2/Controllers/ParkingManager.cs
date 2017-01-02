using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Device.Location;
using LSSProject_2.Models;

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
        public ParkingModel GetParkingAddress(double latitude, double longitude, int range)
        {
            var parking = getClosestParking(latitude, longitude, range);

            if (parking.parkingList.Count==0)
            {
                parking.parkingList.Add(new ParkingObject
                {
                    name = "",
                    latLang = "",
                    spaces = 0
                });
            }

            parking.center = latitude + "," + longitude;
            return parking;
        }

        private ParkingModel getClosestParking(double latitude, double longitude, int range)
        {
            var result = new ParkingModel();
            var min = range>15 ? 15 : (double) range * 1000;//from kilometers to meters
            foreach (var p in parkingList)
            {
                if (p.is_open == 1)
                {
                    var current = getDistance(latitude, longitude, p.latitude, p.longitude);
                    if (current < min)
                    {
                        result.parkingList.Add(mapToParkingObject(p));
                    }
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

        private ParkingObject mapToParkingObject(Parking parking)
        {
            var po = new ParkingObject()
            {
                latLang = parking.latitude + "," + parking.longitude,
                name = parking.name,
                spaces = parking.free_count
            };
            return po;
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
