using MediatR;

namespace App.Lifestyles.Command.CreateLifestyle
{
    public class CreateLifestyleCommand : IRequest<CreateLifestyleResult>
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public bool SmokeCigarettes { get; set; }
        public bool DrinkAlcohol { get; set; }
        public bool Sport { get; set; }
    }
}
