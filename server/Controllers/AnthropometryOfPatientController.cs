using App.AnthropometryOfPatients.Command.CreateAnthropometryOfPatient;
using App.AnthropometryOfPatients.Query.GetAllAnthropometryOfPatients;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/anthropometryOfPatient")]
    public class AnthropometryOfPatientController : ApiController
    {
        private readonly ISender _mediator;

        public AnthropometryOfPatientController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "employee, admin")]
        [HttpPost("createAnthropometryOfPatient")]
        public async Task<IActionResult> CreateAnthropometryOfPatient([FromBody] CreateAnthropometryOfPatientRequest request)
        {
            var query = new CreateAnthropometryOfPatientCommand
            {
                PatientId = request.PatientId,
                Role = request.Role,
                Height = request.Height,
                Weight = request.Weight,
                Age = request.Age,
                Waist = request.Waist,
                Hip = request.Hip
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "employee, admin")]
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
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public double Hip { get; set; }
        public double Waist { get; set; }
    }
}
