using MediatR;

namespace App.BloodAnalysises.Query.GetAllBloodAnalysises
{
    public class GetAllBloodAnalysisesQuery : IRequest<GetAllBloodAnalysisesResult>
    {
        public int ParientId { get; set; }
        public string Role { get; set; }
    }
}
