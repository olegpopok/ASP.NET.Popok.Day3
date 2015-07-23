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
        private const double epsilon = 00000000.1;
        private readonly int degre;
        private readonly int count;
        private double[] coefficients;
        

        public Polynomial():this(new double[1])
        {
        }

        public Polynomial(params double[] coefficients)
        {
            SetCoefficientsHelper(coefficients);
            this.degre = coefficients.Length - 1;
            this.count = coefficients.Length;
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

            for (int i = 1; i < count; i++)
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

            if (this.count != polynom.count)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (Math.Abs(this.coefficients[i] -polynom.coefficients[i]) > epsilon)
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
            double[] coefficients = new double[rhs.count];

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
            for (int index = 0; index < count; index++)
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
                for (int index = 0; index < count; index++)
                {
                    sumGhc += (uint)coefficients[index].GetHashCode();                  
                }

                return (int)(sumGhc % (uint)count); 
            }
        }

        private delegate double OperationEventHandler(double a, double b);

        private void SetCoefficientsHelper(double[] value)
        {
            if ( (value == null) || (value.Length == 0) )
            {
                throw new ArgumentException("coefficients");
            }
            else
            {
                this.coefficients = (double[])value.Clone();
            }
        }

        private static Polynomial AddOrSubOperationHelper(Polynomial lhs, Polynomial rhs, OperationEventHandler operation) 
        {
            double[] coefficients = new double[ (lhs.count > rhs.count) ? lhs.count : rhs.count];

            for (int index = 0; index < coefficients.Length; index++)
            {
                if (index < lhs.count)
                {
                    coefficients[index] = lhs.coefficients[index];
                }
                if (index < rhs.count)
                {
                    coefficients[index] = operation(coefficients[index], rhs.coefficients[index]);
                }
            }

            return new Polynomial(coefficients);
        }
    }
}