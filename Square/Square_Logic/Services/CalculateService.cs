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

    //сделать дома правильную реализацию CalculateService

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
}
