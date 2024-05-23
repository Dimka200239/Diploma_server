using App.DataForFutureLearnings.Command.AddDataForFutureLearningFromExcel;
using App.DataForFutureLearnings.Command.ClearAllDataForFutureLearning;
using App.DataForFutureLearnings.Command.CreateDataForFutureLearning;
using App.DataForFutureLearnings.Query.GetAllDataForFutureLearning;
using Azure.Core;
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

        [Authorize(Roles = "employee, admin")]
        [HttpPost("createDataForFutureLearning")]
        public async Task<IActionResult> CreateDataForFutureLearning([FromBody] CreateDataForFutureLearningRequest request)
        {
            var command = new CreateDataForFutureLearningCommand
            {
                Gender = request.Gender,
                Age = request.Age,
                SmokeCigarettes = request.SmokeCigarettes,
                DrinkAlcohol = request.DrinkAlcohol,
                Sport = request.Sport,
                AmountOfCholesterol = request.AmountOfCholesterol,
                HDL = request.HDL,
                LDL = request.LDL,
                AtherogenicityCoefficient = request.AtherogenicityCoefficient,
                WHI = request.WHI,
                HasCVD = request.HasCVD
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }

    public class AddDataForFutureLearningFromExcelRequest
    {
        public string? PathToExcelFile { get; set; }
    }

    public class CreateDataForFutureLearningRequest
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public bool SmokeCigarettes { get; set; }
        public bool DrinkAlcohol { get; set; }
        public bool Sport { get; set; }
        public double AmountOfCholesterol { get; set; }
        public double HDL { get; set; }
        public double LDL { get; set; }
        public double AtherogenicityCoefficient { get; set; }
        public double WHI { get; set; }

        public int HasCVD { get; set; } //Класс опасности развития ССЗ
    }
}
