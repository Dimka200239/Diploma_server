using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AdultPatients.Query.GetAdultPatientByPassport
{
    public class GetAdultPatientByPassportResult : BaseResult
    {
        public List<GetPatientWithAddressItemList>? AdultPatients { get; set; }
    }

    public class GetPatientWithAddressItemList
    {
        public AdultPatient AdultPatient { get; set; }
        public Address Address { get; set; }
    }
}
