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

        public override string ToString() {
            string lat; string lon;
            if (Latitude >= 0)
            {
                lat = Latitude + " N";
            }
            else
            {
                lat = Latitude * (-1) + " S";
            }

            if (Longitude >= 0)
            {
                lon = Longitude + " E";
            }
            else
            {
                lon = Longitude * (-1) + " W";
            }

            return lat + ", " + lon;
        }
    }
}
