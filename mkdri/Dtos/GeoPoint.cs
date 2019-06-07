namespace MKDRI.Dtos
{
    public class GeoPoint<T> where T: class
    {
        public string Type { get; set; }
        public GeometryInfo Geometry { get; set; }
        public T properties;

        public class GeometryInfo
        {
            public string Type { get; set; }
            public double[] Coordinates { get; set; }
        }

        public GeoPoint(double Longitude, double Latitude, T properties)
        {
            Type = "Feature";
            Geometry = new GeometryInfo { Type = "Point", Coordinates = new double[] { Longitude, Latitude } };
            this.properties = properties;
        }
    }
}
