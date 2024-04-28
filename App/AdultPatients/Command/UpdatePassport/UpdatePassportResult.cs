using App.Common.Abstractions;

namespace App.AdultPatients.Command.UpdatePassport
{
    public class UpdatePassportResult : BaseResult
    {
        public Domain.Classes.AppDBClasses.Passport Passport { get; set; }
    }
}
