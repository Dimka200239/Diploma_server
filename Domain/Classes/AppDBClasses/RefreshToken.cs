using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Classes.AppDBClasses
{
    [Table("RefreshTokens")]
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; } //Сам токен
        public DateTime Created { get; set; } //Дата создания
        public DateTime Expires { get; set; } //Дата истечения
        public DateTime? Revoked { get; set; } //Дата отзыва токена

        public Employee Employee { get; set; }

        public bool IsExpired() => DateTime.UtcNow.ToUniversalTime() >= Expires;
        public bool IsActive() => Revoked == null && !IsExpired();
    }
}
