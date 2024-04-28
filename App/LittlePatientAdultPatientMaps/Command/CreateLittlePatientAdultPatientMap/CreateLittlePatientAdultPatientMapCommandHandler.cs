using App.Common.Interfaces.Persistence;
using App.Passports.Command.CreatePassport;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.LittlePatientAdultPatientMaps.Command.CreateLittlePatientAdultPatientMap
{
    public class CreateLittlePatientAdultPatientMapCommandHandler
        : IRequestHandler<CreateLittlePatientAdultPatientMapCommand, CreateLittlePatientAdultPatientMapResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLittlePatientAdultPatientMapCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateLittlePatientAdultPatientMapResult> Handle(
            CreateLittlePatientAdultPatientMapCommand request,
            CancellationToken cancellationToken)
        {
            var littlePatientAdultPatientMap = new LittlePatientAdultPatientMap
            {
                AdultPatientId = request.AdultPatientId,
                LittlePatientId = request.LittlePatientId
            };

            _unitOfWork.LittlePatientAdultPatientMaps.Add(littlePatientAdultPatientMap);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateLittlePatientAdultPatientMapResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateLittlePatientAdultPatientMapResult
            {
                Success = true,
                LittlePatientAdultPatientMap = littlePatientAdultPatientMap
            };
        }
    }
}
