using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes.AppDBClasses
{
    [Table("BirthCertificates")]
    public class BirthCertificate
    {
        [Key]
        public int LittlePatientId { get; set; }
        public LittlePatient LittlePatient { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
