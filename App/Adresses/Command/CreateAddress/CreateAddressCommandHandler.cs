using App.Common.Interfaces.Persistence;
using App.Passports.Command.CreatePassport;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.Adresses.Command.CreateAddress
{
    public class CreateAddressCommandHandler
        : IRequestHandler<CreateAddressCommand, CreateAddressResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAddressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAddressResult> Handle(
            CreateAddressCommand request,
            CancellationToken cancellationToken)
        {
            var adress = new Address
            {
                PatientId = request.PatientId,
                Role = request.Role,
                City = request.City,
                Street = request.Street,
                House = request.House,
                Apartment = request.Apartment,
                DateOfChange = DateTime.UtcNow
            };

            _unitOfWork.Adresses.Add(adress);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateAddressResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateAddressResult
            {
                Success = true,
                Address = adress
            };
        }
    }
}
