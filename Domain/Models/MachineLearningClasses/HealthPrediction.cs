using Microsoft.ML.Data;

namespace Domain.Models.MachineLearningClasses
{
    public class HealthPrediction
    {
        [ColumnName("PredictedLabel")]
        public int Prediction { get; set; }

        public float[] Score { get; set; }
    }
}
