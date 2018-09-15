using Square_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_Logic.Services
{
    public interface ICalculateService
    {
        void Calculate(Inputs model);
    }

    public class CalculateServiceMoke : ICalculateService
    {
        public void Calculate(Inputs model)
        {
            model.X = new List<double>
            {
                5, -5 //Mocked
            };
        }
    }

    public class CalculateEquation : ICalculateService
    {
        public void Calculate(Inputs model)
        {
            double discriminant = FindDiscriminant(model);
            if (discriminant == 0)
            {
                model.X = new List<double>
                {
                    FindFirstAnswer(model)
                };
                // Add or new List<>?
            }
            if (discriminant > 0)
            {
                model.X = new List<double>
                {
                    FindFirstAnswer(model),
                    FindSecondAnswer(model)
                };
            }
            else
                model.X = new List<double>();
        }

        private double FindDiscriminant(Inputs model)
        {
            return (model.B) * (model.B) - 4 * model.A * model.C;
        }

        private double FindFirstAnswer(Inputs model)
        {
            double temp = ((-model.B + Math.Sqrt(FindDiscriminant(model)))) / (2 * model.A);
            return temp;
        }
        private double FindSecondAnswer(Inputs model)
        {
            return ((-model.B - Math.Sqrt(FindDiscriminant(model))))/ (2 * model.A);
        }
    }
}
