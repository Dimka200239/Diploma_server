using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes.AppDBClasses
{
    [Table("CorrelationValue")]
    public class CorrelationValue
    {
        [Key]
        public int Id { get; set; }
        public double SmokeCigarettes { get; set; }
        public double DrinkAlcohol { get; set; }
        public double Sport { get; set; }
        public double AmountOfCholesterol { get; set; }
        public double HDL { get; set; }
        public double LDL { get; set; }
        public double AtherogenicityCoefficient { get; set; }
        public double WHI { get; set; }
        public int CountOfData { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
