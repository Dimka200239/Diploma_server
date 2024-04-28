using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Lifestyles.Query.GetAllLifestyles
{
    public class GetAllLifestylesResult : BaseResult
    {
        public List<Lifestyle>? Lifestyles { get; set; }
    }
}
