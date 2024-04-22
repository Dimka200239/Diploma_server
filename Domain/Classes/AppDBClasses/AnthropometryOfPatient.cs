using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes.AppDBClasses
{
    [Table("AnthropometryOfPatients")]
    public class AnthropometryOfPatient
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Role { get; set; } //Роль пользователя
        public int Height { get; set; } //Рост
        public int Weight { get; set; } //Вес
        public int Age { get; set; } //Возраст
        public DateTime DateOfChange { get; set; }

        [ForeignKey("PatientId")]
        public AdultPatient AdultPatient { get; set; }

        [ForeignKey("PatientId")]
        public LittlePatient LittlePatient { get; set; }
    }
}
