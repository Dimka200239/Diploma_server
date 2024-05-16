using App.Common.Abstractions;
using Domain.Classes.AppDBClasses;

namespace App.DataForFutureLearnings.Command.AddDataForFutureLearningFromExcel
{
    public class AddDataForFutureLearningFromExcelResult : BaseResult
    {
        public List<DataForFutureLearning>? DataForFutureLearnings { get; set; }
    }
}
