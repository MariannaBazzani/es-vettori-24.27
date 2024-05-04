using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_vettori_24._27
{
    internal class Vector
    {
        public double X { get; }
        public double Y { get; }

        public Vector() { }
        public Vector(double modulo, double angolo) 
        {  
            X = modulo * Math.Cos(angolo); 
            Y = modulo * Math.Sin(angolo); 
        }

        public double Modulo()
        {
            return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
        }
        public double Angolo()
        {
            return Math.Asin(this.X / this.Modulo());
        }
        public override string ToString()
        {
            return string.Format($"{0}, {1}", X, Y);
        }
        public static Vector Parse(string str)
        {
            string[] componenti = str.Split(';');
            return new Vector(double.Parse(componenti[0]), double.Parse(componenti[1]));
        }
        public bool TryParse(string str)
        {
            string[] fattori = str.Split(',');
            if (double.TryParse(fattori[0], out double x) && double.TryParse(fattori[1], out double y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static double operator *(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public static Vector operator *(Vector v1, double a)
        {
            return new Vector(v1.X * a, v1.Y * a);
        }
        public static Vector operator *(double a, Vector v1)
        {
            return new Vector(v1.X * a, v1.Y * a);
        }
        public static Vector operator /(Vector v1, double a)
        {
            return new Vector(v1.X / a, v1.Y / a);
        }
        public static Vector operator -(Vector v1)
        {
            return new Vector(-v1.X, -v1.Y);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            if (ReferenceEquals(v1, null))
                return object.ReferenceEquals(v2, null);
            else if (ReferenceEquals(v2, null))
                return false;
            else
                return v1.X == v2.X && v1.Y == v2.Y;
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !Equals(v1, v2);
        }

        public Vector Versore()
        {
            return this / this.Modulo();
        }
    }
}

