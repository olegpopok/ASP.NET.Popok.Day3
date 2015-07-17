using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public sealed class Polynomial
    {
        public double Variable { get; set; }
        private double[] coefficients;


        public double[] Coefficients 
        {
            get { return this.coefficients; }
            set 
            {
                if (value.Length != 0 && value[value.Length - 1] != 0)
                    this.coefficients = value;
            }
        }

        public int Power 
        {
            get { return coefficients.Length; }
        }

        
    }
}
