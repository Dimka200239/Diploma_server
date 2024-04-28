using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes.AppDBClasses
{
    [Table("LittlePatientAdultPatientMaps")]
    public class LittlePatientAdultPatientMap
    {
        [Key, Column(Order = 0)]
        public int AdultPatientId { get; set; }
        [Key, Column(Order = 1)]
        public int LittlePatientId { get; set; }

        public AdultPatient AdultPatient { get; set; }
        public LittlePatient LittlePatient { get; set; }
    }
}
