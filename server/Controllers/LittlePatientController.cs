using App.LittlePatients.Command.CreateLittlePatient;
using App.LittlePatients.Command.UpdateLittlePatient;
using App.LittlePatients.Query.GetLittlePatientByBirthCertificate;
using App.LittlePatients.Query.GetLittlePatientByName;
using Domain.Models.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Authorize(Roles = "employee")]
    [Route("api/littlePatient")]
    public class LittlePatientController : ApiController
    {
        private readonly ISender _mediator;

        public LittlePatientController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("getLittlePatientByBirthCertificate")]
        public async Task<IActionResult> GetLittlePatientByBirthCertificate([FromBody] GetLittlePatientByBirthCertificateRequest request)
        {
            var query = new GetLittlePatientByBirthCertificateQuery
            {
                Series = request.Series,
                Number = request.Number,
                DateOfIssue = request.DateOfIssue
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("getLittlePatientByName")]
        public async Task<IActionResult> GetLittlePatientByName([FromBody] GetLittlePatientByNameRequest request)
        {
            var query = new GetLittlePatientByNameQuery
            {
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("createLittlePatient")]
        public async Task<IActionResult> CreateLittlePatient([FromBody] CreateLittlePatientRequest request)
        {
            var query = new CreateLittlePatientCommand
            {
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Role = Role.LittlePatient
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("updateLittlePatient")]
        public async Task<IActionResult> UpdateLittlePatient([FromBody] UpdateLittlePatientRequest request)
        {
            var query = new UpdateLittlePatientCommand
            {
                LittlePatientId = request.LittlePatientId,
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class GetLittlePatientByBirthCertificateRequest
    {
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
    }


    public class GetLittlePatientByNameRequest
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class CreateLittlePatientRequest
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class UpdateLittlePatientRequest
    {
        public int LittlePatientId { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
