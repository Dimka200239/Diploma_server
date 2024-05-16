using App.Common.Interfaces.Persistence;
using Domain.Classes.AppDBClasses;
using MediatR;
using OfficeOpenXml;

namespace App.DataForFutureLearnings.Command.AddDataForFutureLearningFromExcel
{
    public class AddDataForFutureLearningFromExcelCommandHandler
        : IRequestHandler<AddDataForFutureLearningFromExcelCommand, AddDataForFutureLearningFromExcelResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDataForFutureLearningFromExcelCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddDataForFutureLearningFromExcelResult> Handle(
            AddDataForFutureLearningFromExcelCommand request,
            CancellationToken cancellationToken)
        {
            var pathToExcel = request.PathToExcelFile;
            var dataForFutureLearningList = new List<DataForFutureLearning>();

            if (pathToExcel is not null)
            {
                if (File.Exists(pathToExcel) && IsExcelFile(pathToExcel))
                {
                    // Устанавливаем лицензионный контекст для EPPlus
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(new FileInfo(pathToExcel)))
                    {
                        var worksheet = package.Workbook.Worksheets[0];

                        int rowCount = worksheet.Dimension.Rows; // Количество строк

                        // Чтение данных из файла
                        for (int row = 2; row <= rowCount; row++)
                        {
                            if (string.IsNullOrWhiteSpace(worksheet.Cells[row, 1].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 2].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 5].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 6].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 7].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 8].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 10].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 11].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 12].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 13].Text) ||
                                string.IsNullOrWhiteSpace(worksheet.Cells[row, 14].Text))
                            {
                                continue;
                            }

                            var dataForFutureLearning = new DataForFutureLearning
                            {
                                Gender = worksheet.Cells[row, 1].Text,
                                Age = int.Parse(worksheet.Cells[row, 2].Text),
                                WHI = double.Parse(worksheet.Cells[row, 5].Text),
                                AmountOfCholesterol = double.Parse(worksheet.Cells[row, 6].Text),
                                HDL = double.Parse(worksheet.Cells[row, 7].Text),
                                LDL = double.Parse(worksheet.Cells[row, 8].Text),
                                AtherogenicityCoefficient = double.Parse(worksheet.Cells[row, 10].Text),
                                SmokeCigarettes = worksheet.Cells[row, 11].Text == "1",
                                DrinkAlcohol = worksheet.Cells[row, 12].Text == "1",
                                Sport = worksheet.Cells[row, 13].Text == "1",
                                HasCVD = int.Parse(worksheet.Cells[row, 14].Text)
                            };

                            dataForFutureLearningList.Add(dataForFutureLearning);
                        }

                        _unitOfWork.DataForFutureLearnings.AddRange(dataForFutureLearningList);
                        var result = await _unitOfWork.CompleteAsync();

                        if (!result)
                            return new AddDataForFutureLearningFromExcelResult
                            {
                                Success = false,
                                Errors = new List<string>() { "Не удалось сохранить данные в БД" }
                            };

                        return new AddDataForFutureLearningFromExcelResult
                        {
                            Success = true,
                            DataForFutureLearnings = dataForFutureLearningList
                        };
                    }
                }
                else
                {
                    return new AddDataForFutureLearningFromExcelResult
                    {
                        Success = false,
                        Errors = new List<string>() { "Файл либо не существует, либо не является файлом Excel" }
                    };
                }
            }

            return new AddDataForFutureLearningFromExcelResult
            {
                Success = false,
                Errors = new List<string>() { "Указан неверный путь к файлу" }
            };
        }

        private bool IsExcelFile(string filePath)
        {
            // Проверяем расширение файла
            string extension = Path.GetExtension(filePath);
            return extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) || extension.Equals(".xls", StringComparison.OrdinalIgnoreCase);
        }
    }
}
