using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.DateForForecastings.Command.AddDateForForecasting
{
    public class AddDateForForecastingCommand : IRequest<AddDateForForecastingResult>
    {
        public List<DateForForecasting>? DateForForecastingList { get; set; }
    }
}
