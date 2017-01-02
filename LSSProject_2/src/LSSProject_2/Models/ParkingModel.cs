using System.Collections.Generic;

namespace LSSProject_2.Models
{
    public class ParkingModel
    {
        public List<ParkingObject> parkingList;
        public string center { get; set; }

        public ParkingModel()
        {
            parkingList = new List<ParkingObject>();
        }

    }

    public class ParkingObject
    {
        public string name { get; set; }
        public string latLang { get; set; }
        public int spaces { get; set; }
    }
}
