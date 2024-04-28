using MediatR;

namespace App.Lifestyles.Query.GetAllLifestyles
{
    public class GetAllLifestylesQuery : IRequest<GetAllLifestylesResult>
    {
        public int ParientId { get; set; }
        public string Role { get; set; }
    }
}
