using App.LittlePatientAdultPatientMaps.Command.CreateLittlePatientAdultPatientMap;
using App.LittlePatientAdultPatientMaps.Query.FindByPatientIdAndRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace server.Controllers
{
    [Authorize(Roles = "employee")]
    [Route("api/littlePatientAdultPatientMapController")]
    public class LittlePatientAdultPatientMapController : ApiController
    {
        private readonly ISender _mediator;

        public LittlePatientAdultPatientMapController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createLittlePatientAdultPatientMap")]
        public async Task<IActionResult> CreateLittlePatientAdultPatientMap([FromBody] LittlePatientAdultPatientMapRequest request)
        {
            var query = new CreateLittlePatientAdultPatientMapCommand
            {
                AdultPatientId = request.AdultPatientId,
                LittlePatientId = request.LittlePatientId,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("findByPatientIdAndRole/{patientId}/{role}")]
        public async Task<IActionResult> FindByPatientIdAndRole(int patientId, string role)
        {
            var query = new FindByPatientIdAndRoleQuery
            {
                PatientId = patientId,
                Role = role,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class LittlePatientAdultPatientMapRequest
    {
        public int AdultPatientId { get; set; }
        public int LittlePatientId { get; set; }
    }
}
