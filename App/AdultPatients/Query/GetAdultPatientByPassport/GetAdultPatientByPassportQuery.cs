using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AdultPatients.Query.GetAdultPatientByPassport
{
    public class GetAdultPatientByPassportQuery : IRequest<GetAdultPatientByPassportResult>
    {
        public string Series { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
