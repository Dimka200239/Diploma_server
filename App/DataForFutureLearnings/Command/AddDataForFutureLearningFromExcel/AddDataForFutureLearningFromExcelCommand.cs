using MediatR;

namespace App.DataForFutureLearnings.Command.AddDataForFutureLearningFromExcel
{
    public class AddDataForFutureLearningFromExcelCommand : IRequest<AddDataForFutureLearningFromExcelResult>
    {
        public string? PathToExcelFile { get; set; }
    }
}
