using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Task1.Library
{
    delegate double Operation(double a, double b);

    public sealed class Polynomial : ICloneable, IEnumerable, IEquatable<Polynomial>
    {
        private double[] coefficients;
        private int count
        {
            get { return coefficients.Length; }
        }

        public Polynomial(params double[] coefficients)
        {
            this.Coefficients = coefficients;
        }

        public Polynomial(): this(0) { }

        public double[] Coefficients
        {
            get { 
                return (double[])this.coefficients.Clone(); 
                }
            set
            {
                if (value.Length != 0)
                    this.coefficients = value;
            }
        }

        public int Power
        {
            get { return this.coefficients.Length -1; }
        }

        public double GetValue(double variable)
        {
            return SumOfMebers(variable);
        }

        public object Clone()
        {
            return new Polynomial((double[])this.coefficients.Clone());
        }

        public IEnumerator GetEnumerator()
        {
            return coefficients.GetEnumerator();
        }

        public bool Equals(Polynomial polynom)
        {
            if (polynom == null)
                return false;
            return this.coefficients.SequenceEqual(polynom.coefficients);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this == obj)
                return true;
            Polynomial polynom = obj as Polynomial;
            if (polynom != null)
                return Equals(polynom);
            else
                return false;
        }

        public static bool operator == (Polynomial a, Polynomial b)
        {
            if ((object)a == null || (object)b == null)
                return Object.Equals(a, b);
            else
                return a.Equals(b);
        }

        public static bool operator != (Polynomial a, Polynomial b)
        {
            if (a == null || b == null)
                return Object.Equals(a,b);
            else
                return !a.Equals(b);
        }

        public static Polynomial operator + ( Polynomial a, Polynomial b)
        {
            if(a.count < b.count)
                Swap(ref a, ref b);
            return ArithmeticOperation(a, b, (x, y) => x + y);
        }

        public static Polynomial operator - (Polynomial a, Polynomial b)
        {
            if (a.count < b.count)
                a = a + new Polynomial(new double[b.count]);
            return ArithmeticOperation(a, b, (x, y) => x - y);
        }

        public static Polynomial operator * (Polynomial a, Polynomial b)
        {
            Polynomial result = new Polynomial();
            for (int i = 0; i < b.count; i++)
            {
                double[] members = new double[a.count + i];
                for (int j = 0; j < a.count; j++)
                    members[j + i] = b.coefficients[i] * a.coefficients[j];
                result = result + new Polynomial(members); 
            }
            return result;
        }

        public override string ToString()
        {
            string result = String.Empty;
            for(int i = 0; i < count; i++)
            {
                result += String.Format("{0} ", coefficients[i]);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        private double SumOfMebers(double variable)
        {
            double sum = new double();
            for (int i = 0; i < count; i++)
            {
                sum += coefficients[i] * Math.Pow(variable, i);
            }
            return sum;
        }

        private static void Swap(ref Polynomial a, ref Polynomial b)
        {
                Polynomial temp = a;
                a = b;
                b = temp;
        }

        private static Polynomial ArithmeticOperation(Polynomial a, Polynomial b, Operation operation) 
        {
            Polynomial result = (Polynomial)a.Clone();
            for (int i = 0; i < (a.count > b.count ? b.count : a.count); i++)
                result.coefficients[i] = 
                    operation(result.coefficients[i], b.coefficients[i]);
            return result;
        }
    }
}