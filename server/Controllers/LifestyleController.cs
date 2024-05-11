using App.Lifestyles.Command.CreateLifestyle;
using App.Lifestyles.Query.GetAllLifestyles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/lifestyle")]
    public class LifestyleController : ApiController
    {
        private readonly ISender _mediator;

        public LifestyleController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "employee, admin")]
        [HttpPost("createLifestyle")]
        public async Task<IActionResult> CreateLifestyle([FromBody] LifestyleRequest request)
        {
            var query = new CreateLifestyleCommand
            {
                PatientId = request.PatientId,
                Role = request.Role,
                SmokeCigarettes = request.SmokeCigarettes,
                DrinkAlcohol = request.DrinkAlcohol,
                Sport = request.Sport
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "employee, admin")]
        [HttpGet("getAllLifestyles/{patientId}/{role}")]
        public async Task<IActionResult> GetAllLifestyles(int patientId, string role)
        {
            var query = new GetAllLifestylesQuery
            {
                ParientId = patientId,
                Role = role
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class LifestyleRequest
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public bool SmokeCigarettes { get; set; }
        public bool DrinkAlcohol { get; set; }
        public bool Sport { get; set; }
    }
}
