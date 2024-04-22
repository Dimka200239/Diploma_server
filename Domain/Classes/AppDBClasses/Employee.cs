using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes.AppDBClasses
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { set; get; } //Логин/email

        [Required]
        public string Password { set; get; } //Пароль
        [Required]
        public DateTime RegistrationDate { set; get; } //Дата регистрации

        [Required]
        public string Role { get; set; } //Роль пользователя
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsConfirm { get; set; } //Подтверждена ли почта

        public ICollection<BloodAnalysis> BloodAnalysises { get; set; } //Анализы
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>(); //Токены обновления
    }
}
