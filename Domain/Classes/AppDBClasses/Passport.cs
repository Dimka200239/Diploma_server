using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes.AppDBClasses
{
    [Table("Passports")]
    public class Passport
    {
        [Key]
        public int AdultPatientId { get; set; }
        public AdultPatient AdultPatient { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
