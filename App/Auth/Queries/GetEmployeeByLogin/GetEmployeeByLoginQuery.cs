using MediatR;

namespace App.Auth.Queries.GetEmployeeByLogin
{
    public class GetEmployeeByLoginQuery : IRequest<GetEmployeeByLoginResult>
    {
        public string Login {  get; set; }
    }
}
