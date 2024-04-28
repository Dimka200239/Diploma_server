using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;

namespace App.BloodAnalysises.Command.CreateBloodAnalysis
{
    public class CreateBloodAnalysisCommandHandler
        : IRequestHandler<CreateBloodAnalysisCommand, CreateBloodAnalysisResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBloodAnalysisCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBloodAnalysisResult> Handle(
            CreateBloodAnalysisCommand request,
            CancellationToken cancellationToken)
        {
            var bloodAnalysis = new BloodAnalysis
            {
                PatientId = request.PatientId,
                Role = request.Role,
                AmountOfCholesterol = request.AmountOfCholesterol,
                HDL = request.HDL,
                LDL = request.LDL,
                VLDL = request.VLDL,
                AtherogenicityCoefficient = request.AtherogenicityCoefficient,
                BMI = request.BMI,
                EmployeeId = request.EmployeeId,
                DateOfChange = DateTime.UtcNow
            };

            _unitOfWork.BloodAnalysises.Add(bloodAnalysis);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
                return new CreateBloodAnalysisResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                };

            return new CreateBloodAnalysisResult
            {
                Success = true,
                BloodAnalysis = bloodAnalysis
            };
        }
    }
}
