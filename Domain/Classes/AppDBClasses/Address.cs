using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Classes.AppDBClasses
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Role { get; set; } //Роль пользователя
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int? Apartment { get; set; }
        public DateTime DateOfChange { get; set; }

        [JsonIgnore]
        [ForeignKey("PatientId")]
        public AdultPatient AdultPatient { get; set; }

    }
}
