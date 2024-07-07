namespace SallaIntegration.Repository.Models
{
    public class AccessToken
    {
        public int Id { get; set; }  // Primary key
        public string AccessTokenValue { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
