using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes.AppDBClasses
{
    [Table("LittlePatients")]
    public class LittlePatient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BirthCertificate BirthCertificate { get; set; }
        public LittlePatientAdultPatientMap LittlePatientAdultPatientMap { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public string Gender { get; set; }
        public ICollection<AnthropometryOfPatient> AnthropometryOfPatients { get; set; }
        public ICollection<Lifestyle> Lifestyles { get; set; }
        public ICollection<BloodAnalysis> BloodAnalysises { get; set; }

        [Required]
        public string Role { get; set; } //Роль пользователя

        public string GetFullName => Name + " " + LastName + " " + MiddleName + " ";
    }
}
