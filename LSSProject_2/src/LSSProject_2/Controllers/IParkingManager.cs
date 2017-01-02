namespace LSSProject_2.Controllers
{
    public interface IParkingManager
    {
        /// <summary>
        /// Gets the parking address based on a location and range
        /// </summary>
        /// <returns>address of nearest parking as string</returns>
        string GetParkingAddress(double latitude, double longitude, int range);
    }
}
