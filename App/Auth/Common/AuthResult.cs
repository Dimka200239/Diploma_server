using App.Common.Abstractions;
using System.Text.Json.Serialization;

namespace App.Auth.Common
{
    public class AuthResult : BaseResult
    {
        public string? Token { get; set; }
        public string? Login { get; set; }
        public string? Role { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
