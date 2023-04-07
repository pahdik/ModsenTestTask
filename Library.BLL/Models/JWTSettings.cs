namespace Library.BLL.Models
{
    public class JWTSettings
    {
        public const string SectionName = "JwtSettings";
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public string Secret { get; init; } = string.Empty;
        public int ExpiryMinutes { get; init; }
    }
}
