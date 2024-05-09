using App.Passports.Command.CreatePassport;
using App.Passports.Query.GetPassport;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/passport")]
    public class PassportController : ApiController
    {
        private readonly ISender _mediator;

        public PassportController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "employee, admin")]
        [HttpPost("createPassport")]
        public async Task<IActionResult> CreatePassport([FromBody] CreatePassportRequest request)
        {
            var query = new CreatePassportCommand
            {
                AdultPatientId = request.AdultPatientId,
                Series = request.Series,
                Number = request.Number,
                Code = request.Code,
                DateOfIssue = request.DateOfIssue
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "employee, admin")]
        [HttpGet("getPassport/{adultPatientId}")]
        public async Task<IActionResult> GetPassport(int adultPatientId)
        {
            var query = new GetPassportQuery
            {
                AdultPatientId = adultPatientId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class CreatePassportRequest
    {
        public int AdultPatientId { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
