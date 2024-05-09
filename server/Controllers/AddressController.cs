using App.Adresses.Command.CreateAddress;
using App.Adresses.Query.GetAllAddresses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [Route("api/address")]
    public class AddressController : ApiController
    {
        private readonly ISender _mediator;

        public AddressController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "employee, admin")]
        [HttpPost("createAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressRequest request)
        {
            var query = new CreateAddressCommand
            {
                PatientId = request.PatientId,
                Role = request.Role,
                City = request.City,
                Street = request.Street,
                House = request.House,
                Apartment = request.Apartment
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Authorize(Roles = "employee, admin")]
        [HttpGet("getAllAddresses/{patientId}/{role}")]
        public async Task<IActionResult>GetAllAddresses(int patientId, string role)
        {
            var query = new GetAllAddressesQuery
            {
                ParientId = patientId,
                Role = role
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

    public class CreateAddressRequest
    {
        public int PatientId { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int? Apartment { get; set; }
    }
}
