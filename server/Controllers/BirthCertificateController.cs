using App.BirthCertificates.Command.CreateBirthCertificate;
using App.BirthCertificates.Query.GetBirthCertificate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Authorize(Roles = "employee")]
    [Route("api/birthCertificate")]
    public class BirthCertificateController : ApiController
    {
        private readonly ISender _mediator;

        public BirthCertificateController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createBirthCertificate")]
        public async Task<IActionResult> CreateBirthCertificate([FromBody] CreateBirthCertificateRequest request)
        {
            var query = new CreateBirthCertificateCommand
            {
                LittlePatientId = request.LittlePatientId,
                Series = request.Series,
                Number = request.Number,
                DateOfIssue = request.DateOfIssue
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("getBirthCertificate/{littlePatientId}")]
        public async Task<IActionResult> GetBirthCertificate(int littlePatientId)
        {
            var query = new GetBirthCertificateQuery
            {
                LittlePatientId = littlePatientId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class CreateBirthCertificateRequest
    {
        public int LittlePatientId { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
