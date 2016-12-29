using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSSProject_2.Controllers
{
    public interface IParkingManager
    {
        /// <summary>
        /// Gets the parking address based on a location
        /// </summary>
        /// <returns>address of nearest parking as string</returns>
        string GetParkingAddress(double latitude, double longitude);
    }
}
