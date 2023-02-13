namespace MyFirstBackend.Models.DataModels
{
    public class UserTokens
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public string UserName { get; set; } = string.Empty;
        public TimeSpan Validity { get; set; }
        public string? RefreshToken { get; set; }
        public string EmailId { get; set; }  = string.Empty;
        public Guid GuidId { get; set; }
        public DateTime? ExpiredTime { get; set; }
        public Role Role { get; set; }
    }
}
