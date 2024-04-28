using App.AnthropometryOfPatients.Command.CreateAnthropometryOfPatient;
using App.AnthropometryOfPatients.Query.GetAllAnthropometryOfPatients;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Authorize(Roles = "employee")]
    [Route("api/anthropometryOfPatient")]
    public class AnthropometryOfPatientController : ApiController
    {
        private readonly ISender _mediator;

        public AnthropometryOfPatientController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createAnthropometryOfPatient")]
        public async Task<IActionResult> CreateAnthropometryOfPatient([FromBody] CreateAnthropometryOfPatientRequest request)
        {
            var query = new CreateAnthropometryOfPatientCommand
            {
                PatientId = request.PatientId,
                Role = request.Role,
                Height = request.Height,
                Weight = request.Weight,
                Age = request.Age
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("getAllAnthropometryOfPatients/{patientId}/{role}")]
        public async Task<IActionResult> GetAllAnthropometryOfPatients(int patientId, string role)
        {
            var query = new GetAllAnthropometryOfPatientsQuery
            {
                ParientId = patientId,
                Role = role
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class CreateAnthropometryOfPatientRequest
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
    }
}
