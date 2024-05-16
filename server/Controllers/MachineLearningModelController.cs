using App.MachineLearningModels.Command.UpdateMachineLearningModel;
using App.MachineLearningModels.Query.GetLastVersion;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace server.Controllers
{
    [Route("api/machineLearningModel")]
    public class MachineLearningModelController : ApiController
    {
        private readonly ISender _mediator;

        public MachineLearningModelController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("updateMachineLearningModel")]
        public async Task<IActionResult> UpdateMachineLearningModel(bool check)
        {
            var emplyeeId = int.Parse(GetUserId());

            var command = new UpdateMachineLearningModelCommand
            {

            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Authorize(Roles = "admin, employee")]
        [HttpGet("getLastVersion")]
        public async Task<IActionResult> GetLastVersion()
        {
            var query = new GetLastVersionQuery
            {

            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
