using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Task1.Library
{
    delegate double Operation(double a, double b);

    public sealed class Polynomial : ICloneable, IEnumerable
    {
        private double[] _coefficients;

        public double[] Coefficients
        {
            get { return _coefficients; }
            set
            {
                if (value.Length != 0 )
                    _coefficients = value;
            }
        }

        public int Power
        {
            get { return _coefficients.Length -1; }
        }

        private int count
        {
            get { return _coefficients.Length; }
        }

        public Polynomial(params double[] coefficients)
        {
            Coefficients = coefficients;
        }

        public Polynomial()
            : this(0){ }

        public double GetValue(double variable)
        {
            return SumOfMebers(variable);
        }

        public object Clone()
        {
            double[] coefficientsClone = new double[count];
            _coefficients.CopyTo(coefficientsClone, 0);
            return new Polynomial(coefficientsClone);
        }

        public IEnumerator GetEnumerator()
        {
            return _coefficients.GetEnumerator();
        }

        public static Polynomial operator +( Polynomial a, Polynomial b)
        {
            return PolynomOperation(a, b, (x, y) => x + y);
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            if (a.count < b.count)
                a = a + new Polynomial(new double[b.count]);
            return PolynomOperation(a, b, (x, y) => x - y);
        }

        public override bool Equals(object obj)
        {
            Polynomial polynom = obj as Polynomial;
            if (polynom != null)
                return PolynomialEquals(polynom);
            return base.Equals(obj);
        }

        private double SumOfMebers(double variable)
        {
            double sum = _coefficients[Power];
            for (int i = 0; i < Power; i++)
                sum += _coefficients[i] * Math.Pow(variable, Power - i);
            return sum;
        }

        private static void SwapIfFirstParamMoThenLast(ref Polynomial a, ref Polynomial b)
        {
            if (a.count < b.count)
            {
                Polynomial temp = a;
                a = b;
                b = temp;
            }
        }

        private static Polynomial PolynomOperation(Polynomial a, Polynomial b, Operation operation) 
        {
            SwapIfFirstParamMoThenLast(ref a, ref b);

            Polynomial sum = (Polynomial)a.Clone();
            for (int i = 0; i < (a.count > b.count ? b.count : a.count); i++)
                sum.Coefficients[i] = 
                    operation(sum.Coefficients[i], b.Coefficients[i]);
            return sum;
        }

        private bool PolynomialEquals( Polynomial p)
        {
            if (this.count == p.count)
            {
                for (int i = 0; i < this.count; i++)
                    if (this._coefficients[i] != p._coefficients[i])
                        return false;
                return true;
            }

            return false;
        }
    }
}
