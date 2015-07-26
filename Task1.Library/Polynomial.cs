using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Task1.Library
{
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private static readonly double epsilon = 0.000000001;
        private readonly int degre;
        private double[] coefficients;
       
        public Polynomial():this(new double[1])
        {
            
        }

        public Polynomial(params double[] coefficients)
        {

            if ((coefficients == null) || (coefficients.Length == 0))
            {
                throw new ArgumentException("coefficients");
            }
            else
            {
                this.coefficients = (double[])coefficients.Clone();
            }

            this.degre = coefficients.Length - 1;
        }

        public int Degre
        {
            get 
            {
                return degre; 
            }
        }
        
        public double this [int index]
        {
            get 
            {
                try
                {
                    return coefficients[index];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
            }
        }

        public double GetValue(double variable)
        {      
            double sum = coefficients[0];

            for (int i = 1; i < this.coefficients.Length; i++)
            {
                sum += coefficients[i] * Math.Pow(variable, i);
            }
            return sum;       
        }

        public object Clone()
        {
            return new Polynomial(coefficients);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;

            }

            Polynomial polynom = obj as Polynomial;
            if (ReferenceEquals(polynom, null))
            {
                return false;
            }

            return Equals(polynom);
        }

        public bool Equals(Polynomial polynom)
        {
            if (ReferenceEquals(polynom, null))
            {
                return false;
            }

            if ((ReferenceEquals(this, polynom)))
            {
                return true;
            }

            if (this.Degre!= polynom.Degre)
            {
                return false;
            }

            for (int i = 0; i < coefficients.Length; i++)
            {
                double sub = Math.Abs(this.coefficients[i] - polynom.coefficients[i]);
                if ( sub > epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator == (Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            {
                return ReferenceEquals(lhs, rhs);
            }
            else
            {
                return lhs.Equals(rhs);
            }
        }

        public static bool operator != (Polynomial lhs, Polynomial rhs)
        {
            if (lhs == null || rhs == null)
                return ReferenceEquals(lhs,rhs);
            else
                return !lhs.Equals(rhs);
        }

        public static Polynomial operator + ( Polynomial lhs, Polynomial rhs)
        {

            return AddOrSubOperationHelper(lhs, rhs, (x, y) => x + y);
        }

        public static Polynomial operator - (Polynomial lhs, Polynomial rhs)
        {
            return AddOrSubOperationHelper(lhs, rhs, (x, y) => x - y);
        }

        public static Polynomial operator *(double lhs, Polynomial rhs)
        {
            double[] coefficients = new double[rhs.coefficients.Length];

            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = rhs.coefficients[i] * lhs;
            }

            return new Polynomial(coefficients);
        }

        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            return lhs + rhs;
        }

        public static Polynomial Sub(Polynomial lhs, Polynomial rhs)
        {
            return lhs - rhs;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < this.coefficients.Length; index++)
            {
                result.AppendFormat("{0} ", coefficients[index]);
            }
            return result.ToString();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                uint sumGhc = 0;
                for (int index = 0; index < coefficients.Length; index++)
                {
                    sumGhc += (uint)coefficients[index].GetHashCode();                  
                }

                return (int)(sumGhc % (uint)2971215073); 
            }
        }

        private static Polynomial AddOrSubOperationHelper(Polynomial lhs, Polynomial rhs, Func<double, double, double> operation) 
        {
            double[] coefficients = new double[ (lhs.coefficients.Length > rhs.coefficients.Length) ?
                lhs.coefficients.Length : rhs.coefficients.Length];

            for (int index = 0; index < coefficients.Length; index++)
            {
                if (index < lhs.coefficients.Length)
                {
                    coefficients[index] = lhs.coefficients[index];
                }
                if (index < rhs.coefficients.Length)
                {
                    coefficients[index] = operation(coefficients[index], rhs.coefficients[index]);
                }
            }

            return new Polynomial(coefficients);
        }
    }
}