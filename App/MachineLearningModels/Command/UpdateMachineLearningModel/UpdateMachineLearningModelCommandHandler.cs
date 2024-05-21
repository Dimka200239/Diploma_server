using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using Domain.Models.MachineLearningClasses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;
using System.Diagnostics;

namespace App.MachineLearningModels.Command.UpdateMachineLearningModel
{
    public class UpdateMachineLearningModelCommandHandler
        : IRequestHandler<UpdateMachineLearningModelCommand, UpdateMachineLearningModelResult>
    {
        private readonly IServiceProvider _serviceProvider;

        public UpdateMachineLearningModelCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<UpdateMachineLearningModelResult> Handle(
            UpdateMachineLearningModelCommand request,
            CancellationToken cancellationToken)
        {
            var scope = _serviceProvider.CreateScope(); // Создание области здесь
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var mlContext = scope.ServiceProvider.GetRequiredService<MLContext>();

            var tcs = new TaskCompletionSource<UpdateMachineLearningModelResult>();

            // Запуск асинхронной задачи и передача зависимостей
            _ = Task.Run(async () =>
            {
                var result = await RetrainModelAsync(unitOfWork, mlContext, scope, cancellationToken);
                tcs.SetResult(result);
            }, cancellationToken);

            return await tcs.Task;
        }

        private async Task<UpdateMachineLearningModelResult> RetrainModelAsync(IUnitOfWork unitOfWork, MLContext mlContext, IServiceScope scope, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var lastVersion = await unitOfWork.MachineLearningModels.GetLastVersion();
                var dateForForecastingsList = await unitOfWork.DateForForecastings.FindAll();

                if (dateForForecastingsList == null || !dateForForecastingsList.Any())
                {
                    return new UpdateMachineLearningModelResult
                        {
                            Success = false,
                            Errors = new List<string>() { "Нет данных для переобучения модели" }
                        };
                }

                if (lastVersion is not null)
                {
                    if (lastVersion.CountOfData == dateForForecastingsList.Count)
                    {
                        return new UpdateMachineLearningModelResult
                        {
                            Success = false,
                            Errors = new List<string>() { "Нет новых данных для переобучения модели. Добавьте новые данные, чтобы модель переобучилась корректно" }
                        };
                    }
                }

                var dataList = new List<HealthData>();

                foreach (var item in dateForForecastingsList)
                {
                    var newHealthData = new HealthData
                    {
                        Gender = item.Gender.Equals("m") ? 0f : 1f,
                        Age = (float)item.Age,
                        SmokeCigarettes = item.SmokeCigarettes == true ? 0f : 1f,
                        DrinkAlcohol = item.DrinkAlcohol == true ? 0f : 1f,
                        Sport = item.Sport == true ? 0f : 1f,
                        AmountOfCholesterol = (float)item.AmountOfCholesterol,
                        HDL = (float)item.HDL,
                        LDL = (float)item.LDL,
                        AtherogenicityCoefficient = (float)item.AtherogenicityCoefficient,
                        WHI = (float)item.WHI,
                        HasCVD = (float)item.HasCVD
                    };

                    dataList.Add(newHealthData);
                }

                IDataView dataView = mlContext.Data.LoadFromEnumerable(dataList);
                var dataSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
                IDataView trainData = dataSplit.TrainSet;
                IDataView testData = dataSplit.TestSet;

                var pipeline = mlContext.Transforms.Concatenate("Features", "Gender", "Age", "SmokeCigarettes", "DrinkAlcohol", "Sport", "AmountOfCholesterol", "HDL", "LDL", "AtherogenicityCoefficient", "WHI")
                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "Label", inputColumnName: "HasCVD"))
                    .Append(mlContext.MulticlassClassification.Trainers.LightGbm())
                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName: "PredictedLabel"));

                var model = pipeline.Fit(trainData);

                var predictions = model.Transform(testData);
                var metrics = mlContext.MulticlassClassification.Evaluate(predictions);
                Console.WriteLine($"Log-loss: {metrics.LogLoss}, Per class Log-loss: {string.Join(" ", metrics.PerClassLogLoss)}");

                var machineLearningModel = new MachineLearningModel().CreateFromModel(model, trainData, dateForForecastingsList.Count);
                unitOfWork.MachineLearningModels.Add(machineLearningModel);
                var result = await unitOfWork.CompleteAsync();

                if (!result)
                {
                    return new UpdateMachineLearningModelResult
                    {
                        Success = false,
                        Errors = new List<string>() { "Не удалось сохранить переобученную модель в БД" }
                    };
                }

                Console.WriteLine($"Model training completed in {stopwatch.Elapsed.TotalSeconds} seconds");

                return new UpdateMachineLearningModelResult
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Console.WriteLine($"Model training failed after {stopwatch.Elapsed.TotalSeconds} seconds. Error: {ex.Message}");

                return new UpdateMachineLearningModelResult
                {
                    Success = false,
                    Errors = new List<string>() { "Возникла ошибка при переобучении модели" }
                };
            }
            finally
            {
                stopwatch.Stop();
                scope.Dispose();
            }
        }
    }
}
