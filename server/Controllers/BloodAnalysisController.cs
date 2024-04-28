using App.BloodAnalysises.Command.CreateBloodAnalysis;
using App.BloodAnalysises.Query.GetAllBloodAnalysises;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Authorize(Roles = "employee")]
    [Route("api/bloodAnalysis")]
    public class BloodAnalysisController : ApiController
    {
        private readonly ISender _mediator;

        public BloodAnalysisController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createBloodAnalysis")]
        public async Task<IActionResult> CreateBloodAnalysis([FromBody] BloodAnalysisRequest request)
        {
            var emplyeeId = int.Parse(GetUserId());

            var query = new CreateBloodAnalysisCommand
            {
                PatientId = request.PatientId,
                Role = request.Role,
                AmountOfCholesterol = request.AmountOfCholesterol,
                HDL = request.HDL,
                LDL = request.LDL,
                VLDL = request.VLDL,
                AtherogenicityCoefficient = request.AtherogenicityCoefficient,
                BMI = request.BMI,
                EmployeeId = emplyeeId
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("getAllBloodAnalysises/{patientId}/{role}")]
        public async Task<IActionResult> GetAllBloodAnalysises(int patientId, string role)
        {
            var query = new GetAllBloodAnalysisesQuery
            {
                ParientId = patientId,
                Role = role
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class BloodAnalysisRequest
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public double AmountOfCholesterol { get; set; }
        public double HDL { get; set; }
        public double LDL { get; set; }
        public double VLDL { get; set; }
        public double AtherogenicityCoefficient { get; set; }
        public double BMI { get; set; }
    }
}
