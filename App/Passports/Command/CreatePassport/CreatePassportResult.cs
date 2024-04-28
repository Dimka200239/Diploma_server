using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Passports.Command.CreatePassport
{
    public class CreatePassportResult : BaseResult
    {
        public Passport Passport { get; set; }
    }
}
