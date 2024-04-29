using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Auth.Queries.GetEmployeeByLogin
{
    public class GetEmployeeByLoginResult : BaseResult
    {
        public Employee Employee { get; set; }
    }
}
