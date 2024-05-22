using App.Correlations.Command.GetCorrelation;
using App.Correlations.Query.GetLastCorrelationValue;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/correlation")]
    public class CorrelationController : ApiController 
    {
        private readonly ISender _mediator;

        public CorrelationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("getCorrelation")]
        public async Task<IActionResult> GetCorrelation()
        {
            var command = new GetCorrelationCommand
            {

            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Authorize(Roles = "admin, employee")]
        [HttpGet("getLastCorrelationValue")]
        public async Task<IActionResult> GetLastCorrelationValue()
        {
            var query = new GetLastCorrelationValueQuery
            {

            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
