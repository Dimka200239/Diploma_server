using App.DataForFutureLearnings.Command.AddDataForFutureLearningFromExcel;
using App.DataForFutureLearnings.Command.ClearAllDataForFutureLearning;
using App.DataForFutureLearnings.Query.GetAllDataForFutureLearning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/dataForFutureLearning")]
    public class DataForFutureLearningController : ApiController
    {
        private readonly ISender _mediator;

        public DataForFutureLearningController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addDataForFutureLearningFromExcel")]
        public async Task<IActionResult> AddDataForFutureLearningFromExcel([FromBody] AddDataForFutureLearningFromExcelRequest request)
        {
            var emplyeeId = int.Parse(GetUserId());

            var command = new AddDataForFutureLearningFromExcelCommand
            {
                PathToExcelFile = request.PathToExcelFile
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("getAllDataForFutureLearning")]
        public async Task<IActionResult> GetAllDataForFutureLearning()
        {
            var emplyeeId = int.Parse(GetUserId());

            var query = new GetAllDataForFutureLearningQuery
            {

            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("clearAllDataForFutureLearning")]
        public async Task<IActionResult> ClearAllDataForFutureLearning()
        {
            var emplyeeId = int.Parse(GetUserId());

            var query = new ClearAllDataForFutureLearningCommand
            {

            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        //[Authorize(Roles = "employee, admin")]
        //[HttpPost("createDataForFutureLearning")]
        //public async Task<IActionResult> CreateDataForFutureLearning()
        //{

        //}
    }

    public class AddDataForFutureLearningFromExcelRequest
    {
        public string? PathToExcelFile { get; set; }
    }
}
