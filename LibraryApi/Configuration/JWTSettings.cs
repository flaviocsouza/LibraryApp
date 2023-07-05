namespace LibraryApi.Configuration
{
    public class JWTSettings
    {
        public string Secret { get; set; }
        public double HoursToExpire { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
