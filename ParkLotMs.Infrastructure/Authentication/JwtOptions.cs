
namespace ParkLotMs.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string Issueer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}
