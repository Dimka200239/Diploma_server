using App.DateForForecastings.Command.AddDateForForecasting;
using Domain.Classes.AppDBClasses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/dateForForecasting")]
    public class DateForForecastingController : ApiController
    {
        private readonly ISender _mediator;

        public DateForForecastingController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addDateForForecasting")]
        public async Task<IActionResult> AddDateForForecasting([FromBody] AddDateForForecastingRequest request)
        {
            var emplyeeId = int.Parse(GetUserId());

            var command = new AddDateForForecastingCommand
            {
                DateForForecastingList = request.DateForForecastingList
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }

    public class AddDateForForecastingRequest
    {
        public List<DateForForecasting>? DateForForecastingList {  get; set; }
    }
}
