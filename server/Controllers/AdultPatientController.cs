using App.AdultPatients.Command.CreateAdultPatient;
using App.AdultPatients.Command.UpdateAdultPatient;
using App.AdultPatients.Command.UpdatePassport;
using App.AdultPatients.Query.GetAdultPatientByName;
using App.AdultPatients.Query.GetAdultPatientByPassport;
using Domain.Models.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Authorize(Roles = "employee")]
    [Route("api/adultPatient")]
    public class AdultPatientController : ApiController
    {
        private readonly ISender _mediator;

        public AdultPatientController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("getAdultPatientByPassport")]
        public async Task<IActionResult> GetAdultPatientByPassport([FromBody] GetAdultPatientByPassportRequest request)
        {
            var query = new GetAdultPatientByPassportQuery
            {
                Series = request.Series,
                Number = request.Number,
                Code = request.Code,
                DateOfIssue = request.DateOfIssue
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("getAdultPatientByName")]
        public async Task<IActionResult> GetAdultPatientByName([FromBody] GetAdultPatientByNameRequest request)
        {
            var query = new GetAdultPatientByNameQuery
            {
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("createAdultPatient")]
        public async Task<IActionResult> CreateAdultPatient([FromBody] CreateAdultPatientRequest request)
        {
            var query = new CreateAdultPatientCommand
            {
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Role = Role.AdultPatient
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("updateAdultPatient")]
        public async Task<IActionResult> UpdateAdultPatient([FromBody] UpdateAdultPatientRequest request)
        {
            var query = new UpdateAdultPatientCommand
            {
                AdultPatientId = request.AdultPatientId,
                Name = request.Name,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("updatePassport")]
        public async Task<IActionResult> UpdatePassport([FromBody] UpdatePassportRequest request)
        {
            var query = new UpdatePassportCommand
            {
                AdultPatientId = request.AdultPatientId,
                NewSeries = request.Series,
                NewNumber = request.Number,
                NewCode = request.Code,
                NewDateOfIssue = request.DateOfIssue
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class GetAdultPatientByPassportRequest
    {
        public string Series {  get; set; }
        public string Number {  get; set; }
        public string Code {  get; set; }
        public DateTime DateOfIssue { get; set; }
    }


    public class GetAdultPatientByNameRequest
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class CreateAdultPatientRequest
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
    }

    public class UpdateAdultPatientRequest
    {
        public int AdultPatientId {  get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UpdatePassportRequest
    {
        public int AdultPatientId { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
