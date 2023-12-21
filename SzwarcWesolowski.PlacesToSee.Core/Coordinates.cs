namespace SzwarcWesolowski.PlacesToSee.Core
{
    public record struct Coordinates
    {
        /// <summary>
        /// North-South axis
        /// </summary>
        public double Latitude;

        /// <summary>
        /// East-West axis
        /// </summary>
        public double Longitude;

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
