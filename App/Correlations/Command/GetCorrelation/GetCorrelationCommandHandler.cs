using App.Common.Interfaces.Persistence;
using App.MachineLearningModels.Command.UpdateMachineLearningModel;
using Domain.Classes.AppDBClasses;
using Domain.Models.MachineLearningClasses;
using MathNet.Numerics.Distributions;
using MediatR;

namespace App.Correlations.Command.GetCorrelation
{
    public class GetCorrelationCommandHandler
        : IRequestHandler<GetCorrelationCommand, GetCorrelationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCorrelationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCorrelationResult> Handle(
            GetCorrelationCommand request,
            CancellationToken cancellationToken)
        {
            var dateForForecastingsList = await _unitOfWork.DateForForecastings.FindAll();
            var lastVersion = await _unitOfWork.CorrelationValues.GetLastVersion();

            if (dateForForecastingsList == null || !dateForForecastingsList.Any())
            {
                return new GetCorrelationResult
                {
                    Success = false,
                    Errors = new List<string>() { "Нет данных для корреляционной статистики" }
                };
            }

            if (lastVersion is not null)
            {
                if (lastVersion.CountOfData == dateForForecastingsList.Count)
                {
                    return new GetCorrelationResult
                    {
                        Success = false,
                        Errors = new List<string>() { "Вы уже делали корреляцционную статистику на этом наборе данных " }
                    };
                }
            }

            List<float> SmokeCigaretteses = new List<float>();
            List<float> DrinkAlcohols = new List<float>();
            List<float> Sports = new List<float>();
            List<float> AmountOfCholesterols = new List<float>();
            List<float> HDLs = new List<float>();
            List<float> LDLs = new List<float>();
            List<float> AtherogenicityCoefficients = new List<float>();
            List<float> WHIs = new List<float>();
            List<float> HasCVDs = new List<float>();

            foreach (var item in dateForForecastingsList)
            {
                SmokeCigaretteses.Add(item.SmokeCigarettes == true ? 0f : 1f);
                DrinkAlcohols.Add(item.DrinkAlcohol == true ? 0f : 1f);
                Sports.Add(item.Sport == true ? 0f : 1f);
                AmountOfCholesterols.Add((float)item.AmountOfCholesterol);
                HDLs.Add((float)item.HDL);
                LDLs.Add((float)item.LDL);
                AtherogenicityCoefficients.Add((float)item.AtherogenicityCoefficient);
                WHIs.Add((float)item.WHI);
                HasCVDs.Add((float)item.HasCVD);
            }

            // Список всех параметров
            List<List<float>> parameters = new List<List<float>>
            {
                SmokeCigaretteses,
                DrinkAlcohols,
                Sports,
                AmountOfCholesterols,
                HDLs,
                LDLs,
                AtherogenicityCoefficients,
                WHIs
            };

            string[] parameterNames = {
                "Smoking",
                "Alcohol Consumption",
                "Physical Activity",
                "Cholesterol",
                "HDL",
                "LDL",
                "Atherogenic Coefficient",
                "Waist/Hip Ratio"
            };

            Dictionary<string, double> correlationResults = new Dictionary<string, double>();

            for (int i = 0; i < parameters.Count; i++)
            {
                double correlation;
                if (ShapiroWilkTest(parameters[i]))
                {
                    correlation = PearsonCorrelation(parameters[i], HasCVDs.Select(x => (float)x).ToList());
                }
                else
                {
                    correlation = SpearmanCorrelation(parameters[i], HasCVDs.Select(x => (float)x).ToList());
                }

                correlationResults[parameterNames[i]] = correlation;
                Console.WriteLine($"Корреляция между {parameterNames[i]} и риском сердечно-сосудистых заболеваний: {correlation}");
            }

            var newCorrelationValue = new CorrelationValue
            {
                SmokeCigarettes = Math.Round(correlationResults["Smoking"], 2),
                DrinkAlcohol = Math.Round(correlationResults["Alcohol Consumption"], 2),
                Sport = Math.Round(correlationResults["Physical Activity"], 2),
                AmountOfCholesterol = Math.Round(correlationResults["Cholesterol"], 2),
                HDL = Math.Round(correlationResults["HDL"], 2),
                LDL = Math.Round(correlationResults["LDL"], 2),
                AtherogenicityCoefficient = Math.Round(correlationResults["Atherogenic Coefficient"], 2),
                WHI = Math.Round(correlationResults["Waist/Hip Ratio"], 2),
                CountOfData = dateForForecastingsList.Count,
                CreatedDate = DateTime.UtcNow
            };

            _unitOfWork.CorrelationValues.Add(newCorrelationValue);
            var result = await _unitOfWork.CompleteAsync();

            if (!result)
            {
                return new GetCorrelationResult
                {
                    Success = false,
                    Errors = new List<string>() { "Не удалось сохранить данные о корреляционной статистике" }
                };
            }

            return new GetCorrelationResult
            {
                Success = true
            };
        }

        private bool ShapiroWilkTest(List<float> values)
        {
            double[] data = values.Select(v => (double)v).ToArray();
            Array.Sort(data);

            int n = data.Length;

            if (n <= 50)
            {
                var shapiroWilkTest = new ShapiroWilkTest(data);
                return shapiroWilkTest.PValue > 0.05;
            }

            double[] m = new double[n];
            for (int i = 0; i < n; i++)
            {
                m[i] = Normal.InvCDF(0, 1, (i + 1.0 - 0.375) / (n + 0.25));
            }

            double mSum = m.Sum();
            for (int i = 0; i < n; i++)
            {
                m[i] -= mSum / n;
            }

            double[] a = new double[n];
            double mDotM = m.Select(mi => mi * mi).Sum();
            for (int i = 0; i < n; i++)
            {
                a[i] = m[i] / Math.Sqrt(mDotM);
            }

            double mean = data.Average();
            double stdDev = Math.Sqrt(data.Select(val => Math.Pow(val - mean, 2)).Sum() / data.Length);

            double b = data.Zip(a, (di, ai) => ai * (di - mean)).Sum();
            double W = Math.Pow(b, 2) / data.Select(val => Math.Pow(val - mean, 2)).Sum();

            double mu = -1.2725 + (1.0521 * (Math.Log(n) - Math.Log(2.0)));
            double sigma = 1.0308 - (0.26758 * (Math.Log(n) - Math.Log(2.0)));
            double z = (Math.Log(1.0 - W) - mu) / sigma;
            double pValue = Normal.CDF(0, 1, z);

            return pValue > 0.05;
        }

        private double PearsonCorrelation(List<float> x, List<float> y)
        {
            if (x.Count != y.Count)
                throw new ArgumentException("The number of elements in both lists must be equal.");

            double meanX = x.Average();
            double meanY = y.Average();

            double numerator = 0;
            double denominatorX = 0;
            double denominatorY = 0;

            for (int i = 0; i < x.Count; i++)
            {
                double diffX = x[i] - meanX;
                double diffY = y[i] - meanY;

                numerator += diffX * diffY;
                denominatorX += diffX * diffX;
                denominatorY += diffY * diffY;
            }

            return numerator / Math.Sqrt(denominatorX * denominatorY);
        }

        private double SpearmanCorrelation(List<float> x, List<float> y)
        {
            if (x.Count != y.Count)
                throw new ArgumentException("The number of elements in both lists must be equal.");

            var rankedX = GetRanks(x);
            var rankedY = GetRanks(y);

            double meanRankX = rankedX.Average();
            double meanRankY = rankedY.Average();

            double covariance = 0;
            double varianceX = 0;
            double varianceY = 0;

            for (int i = 0; i < x.Count; i++)
            {
                double diffX = rankedX[i] - meanRankX;
                double diffY = rankedY[i] - meanRankY;

                covariance += diffX * diffY;
                varianceX += diffX * diffX;
                varianceY += diffY * diffY;
            }

            return covariance / Math.Sqrt(varianceX * varianceY);
        }

        private List<float> GetRanks(List<float> values)
        {
            var sorted = values.Select((v, i) => new { Value = v, Index = i })
                               .OrderBy(x => x.Value)
                               .ToList();

            List<float> ranks = new List<float>(new float[values.Count]);
            double rank = 1;

            for (int i = 0; i < sorted.Count; i++)
            {
                if (i > 0 && sorted[i].Value != sorted[i - 1].Value)
                    rank = i + 1;

                ranks[sorted[i].Index] = (float)rank;
            }

            return ranks;
        }
    }

    public class ShapiroWilkTest
    {
        public double W { get; private set; }
        public double PValue { get; private set; }

        public ShapiroWilkTest(double[] data)
        {
            int n = data.Length;
            if (n < 3 || n > 5000)
                throw new ArgumentException("Shapiro-Wilk test is not defined for sample sizes less than 3 or greater than 5000.");

            double[] a = GetShapiroWilkCoefficients(n);

            double mean = data.Average();
            double b = data.Zip(a, (di, ai) => ai * (di - mean)).Sum();
            W = Math.Pow(b, 2) / data.Select(val => Math.Pow(val - mean, 2)).Sum();

            // Here you should use the appropriate p-value calculation as per the Real Statistics website
            PValue = ComputePValue(W, n); // Placeholder for actual p-value computation
        }

        private double[] GetShapiroWilkCoefficients(int n)
        {
            // Placeholder for the actual coefficients, please refer to the Real Statistics website or literature
            return Enumerable.Range(1, n).Select(i => 1.0 / i).ToArray();
        }

        private double ComputePValue(double W, int n)
        {
            // Placeholder for the actual p-value computation
            return Normal.CDF(0, 1, W); // This is an approximation
        }
    }
}
