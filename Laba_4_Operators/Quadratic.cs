using System;

namespace LABA_4_OPERATORS
{
    internal class QuadraticEquation
    {
        private double _a;
        private double _b;
        private double _c;

        public QuadraticEquation()
        {
            _a = 1;
            _b = 0;
            _c = 0;
        }

        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public QuadraticEquation(QuadraticEquation other)
        {
            _a = other._a;
            _b = other._b;
            _c = other._c;
        }

        public double A
        {
            get { return _a; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Коэффициент a не может быть равен 0 :( Установлено a = 1");
                    _a = 1;
                }
                else
                {
                    _a = value;
                }
            }
        }

        public double B
        {
            get { return _b; }
            set { _b = value; }
        }

        public double C
        {
            get { return _c; }
            set { _c = value; }
        }

        public double[] GetRoots()
        {
            double discriminant = GetDiscriminant();
            double sqrt;
            double[] roots;

            if (discriminant < 0)
            {
                roots = new double[0];
            }
            else if (discriminant == 0)
            {
                roots = new double[1];
                roots[0] = -_b / (2 * _a);
            }
            else
            {
                sqrt = Math.Sqrt(discriminant);
                roots = new double[2];
                roots[0] = (-_b - sqrt) / (2 * _a);
                roots[1] = (-_b + sqrt) / (2 * _a);
            }

            return roots;
        }

        private double GetDiscriminant()
        {
            return _b * _b - 4 * _a * _c;
        }

        public override string ToString()
        {
            string signB = "+";
            string signC = "+";
            double absB = _b;
            double absC = _c;

            if (_b < 0)
            {
                signB = "-";
                absB = -_b;
            }

            if (_c < 0)
            {
                signC = "-";
                absC = -_c;
            }

            return _a + "x² " + signB + " " + absB + "x " + signC + " " + absC + " = 0";
        }

        public static QuadraticEquation operator ++(QuadraticEquation e)
        {
            return new QuadraticEquation(e._a + 1, e._b + 1, e._c + 1);
        }

        public static QuadraticEquation operator --(QuadraticEquation e)
        {
            return new QuadraticEquation(e._a - 1, e._b - 1, e._c - 1);
        }

        public static implicit operator double(QuadraticEquation e)
        {
            return e.GetDiscriminant();
        }

        public static explicit operator bool(QuadraticEquation e)
        {
            return e.GetDiscriminant() >= 0;
        }

        public static bool operator ==(QuadraticEquation e1, QuadraticEquation e2)
        {
            if (ReferenceEquals(e1, null) || ReferenceEquals(e2, null))
            {
                return ReferenceEquals(e1, e2);
            }

            return e1._a == e2._a && e1._b == e2._b && e1._c == e2._c;
        }

        public static bool operator !=(QuadraticEquation e1, QuadraticEquation e2)
        {
            return !(e1 == e2);
        }
    }
}