using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.AdultPatients.Query.GetAdultPatientByName
{
    public class GetAdultPatientByNameResult : BaseResult
    {
        public List<GetPatientWithAddressItemList>? AdultPatients { get; set; }
    }

    public class GetPatientWithAddressItemList
    {
        public AdultPatient AdultPatient { get; set; }
        public Address Address { get; set; }
    }
}
