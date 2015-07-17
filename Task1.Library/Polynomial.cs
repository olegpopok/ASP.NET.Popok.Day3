using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public sealed class Polynomial
    {
        private double[] _coefficients;

        public double[] Coefficients
        {
            get { return _coefficients; }
            set
            {
                if (value.Length != 0 && value[0] != 0)
                    _coefficients = value;
            }
        }

        public int Power
        {
            get { return _coefficients.Length -1; }
        }

        public Polynomial(params double[] coefficients)
        {
            Coefficients = coefficients;
        }

        public Polynomial()
            : this(1){ }

        public double GetValue(double variable)
        {
            return SumOfMebers(variable);
        }

        private double SumOfMebers(double variable)
        {
            double sum = _coefficients[Power];
            for (int i = 0; i < Power; i++)
                sum += _coefficients[i] * Math.Pow(variable, Power - i);
            return sum;
        }
           
    }
}
