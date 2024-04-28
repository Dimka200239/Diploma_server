using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Passports.Query.GetPassport
{
    public class GetPassportResult : BaseResult
    {
        public Passport Passport { get; set; }
    }
}
