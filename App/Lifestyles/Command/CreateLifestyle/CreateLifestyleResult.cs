using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.Lifestyles.Command.CreateLifestyle
{
    public class CreateLifestyleResult : BaseResult
    {
        public Lifestyle? Lifestyle { get; set; }
    }
}
