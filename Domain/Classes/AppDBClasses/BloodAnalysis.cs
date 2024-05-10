using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Classes.AppDBClasses
{
    [Table("BloodAnalysises")]
    public class BloodAnalysis
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Role { get; set; } //Роль пользователя
        public double AmountOfCholesterol { get; set; } //Кол-во холестерина в крови
        public double HDL { get; set; } //Кол-во ЛПВП в крови
        public double LDL { get; set; } //Кол-во ЛПНП в крови
        public double VLDL { get; set; } //Кол-во ЛПОНП в крови
        public double AtherogenicityCoefficient { get; set; } //Коэффицент атерогенности
        public double BMI { get; set; } //Индекс массы тела
        public double WHI { get; set; } //Индекс талии/бедра
        public DateTime DateOfChange { get; set; }
        public int EmployeeId { set; get; }

        [JsonIgnore]
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [JsonIgnore]
        [ForeignKey("PatientId")]
        public AdultPatient AdultPatient { get; set; }
    }
}
