namespace FileToDBProgram
{
    public class PointOfInterest
    {
        public string RegionID;
        public string RegionName;
        public string RegionNameLong;
        public string Latitude;
        public string Longitude;
        public string SubClassification;

        public PointOfInterest(string RegionID, string RegionName, string RegionNameLong, string Latitude, string Longitude, string SubClassification)
        {
            this.RegionID = RegionID;
            this.RegionName = RegionName;
            this.RegionNameLong = RegionNameLong;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.SubClassification = SubClassification;
        }
    }
}
