using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perimeter_and_area
{
    class Program
    {
        public abstract class shape
        {
            public abstract double Perimeter();
            public abstract double area();
        }
        public class Triangle : shape
        {
            public double Ax { get; set; }
            public double Ay { get; set; }
            public double Bx { get; set; }
            public double By { get; set; }
            public double Cx { get; set; }
            public double Cy { get; set; }
            public Triangle(double e1x, double e1y, double e2x, double e2y, double e3x, double e3y)
            {
                Ax = e1x;
                Ay = e1y;
                Bx = e2x;
                By = e2y;
                Cx = e3x;
                Cy = e3y;
            }
            public static Triangle operator -(Triangle num1, Triangle num2)
            {

            }
            public override double Perimeter()
            {
                double a1 = Bx - Cx;
                double a2 = By - Cy;
                double a3 = Math.Pow(a1, 2) + Math.Pow(a2, 2);
                double a = Math.Sqrt(a3);
                double b1 = Ax - Cx;
                double b2 = Ay - Cy;
                double b3 = Math.Pow(b1, 2) + Math.Pow(b2, 2);
                double b = Math.Sqrt(b3);
                double c1 = Ax - Bx;
                double c2 = Ay - By;
                double c3 = Math.Pow(c1, 2) + Math.Pow(c2, 2);
                double c = Math.Sqrt(c3);
                return a + b + c;
            }
            public override double area()
            {
                double a1 = Bx - Cx;
                double a2 = By - Cy;
                double a3 = Math.Pow(a1, 2) + Math.Pow(a2, 2);
                double a = Math.Sqrt(a3);
                double b1 = Ax - Cx;
                double b2 = Ay - Cy;
                double b3 = Math.Pow(b1, 2) + Math.Pow(b2, 2);
                double b = Math.Sqrt(b3);
                double c1 = Ax - Bx;
                double c2 = Ay - By;
                double c3 = Math.Pow(c1, 2) + Math.Pow(c2, 2);
                double c = Math.Sqrt(c3);
                var s = Perimeter() / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }
        public class Circle : shape
        {
            public double center_x { get; set; }
            public double center_y { get; set; }
            public double p_x { get; set; }
            public double p_y { get; set; }
            public double r { get; set; }

            public Circle(double cx, double cy, double px, double py)
            {
                center_x = cx;
                center_y = cy;
                p_x = px;
                p_y = py;
                if (cx == px)
                {
                    r = Math.Abs(cy - py);
                }
                else if (cy == py)
                {
                    r = Math.Abs(cx - px);
                }
                else
                {
                    double i = Math.Abs(cy - py);
                    double i1 = Math.Abs(cx - px);
                    r = Math.Sqrt(Math.Pow(i, 2) + Math.Pow(i1, 2));
                }
            }

            public override double Perimeter()
            {
                return 2 * r * Math.PI;
            }
            public override double area()
            {
                    return r * r * Math.PI;
            }
        }
        public class square : shape
        {
            public double Ax { get; set; }
            public double Ay { get; set; }
            public double Bx { get; set; }
            public double By { get; set; }
            public double Cx { get; set; }
            public double Cy { get; set; }
            public double Dx { get; set; }
            public double Dy { get; set; }
            public square (double ax,double ay, double bx, double by, double cx, double cy, double dx, double dy)
            {
                Ax = ax;
                Ay = ay;
                Bx = bx;
                By = by;
                Cx = cx;
                Cy = cy;
                Dx = dx;
                Dy = dy;
            }
            public static square operator - (square num1, square num2)
            {
                var newwidth = num1.area() / (num2.Ay - num2.By);
                var newlength = num1.area() / newwidth;
                return new square((num2.Ay - num2.By), (num2.Cx - num2.Bx) - newlength);
            }
            public override double area()
            {
                double abc = 1/2 * Math.Abs(Ax * (By - Cy) + Bx * (Cy - Ay) + Cx * (Ay - By));
                double acd = 1/2 * Math.Abs(Ax * (Dy - Cy) + Dx * (Cy - Ay) + Cx * (Ay - Dy));
                return abc + acd;
            }
            public override double Perimeter()
            {
                double i = Math.Abs(Ay - By);
                double i1 = Math.Abs(Ax -Bx);
                double a = Math.Sqrt(Math.Pow(i, 2) + Math.Pow(i1, 2));
                double g = Math.Abs(Cy - By);
                double g1 = Math.Abs(Cx - Bx);
                double b = Math.Sqrt(Math.Pow(g, 2) + Math.Pow(g1, 2));
                double f = Math.Abs(Cy - Dy);
                double f1 = Math.Abs(Cx - Dx);
                double c = Math.Sqrt(Math.Pow(f, 2) + Math.Pow(f1, 2));
                double s = Math.Abs(Ay - Dy);
                double s1 = Math.Abs(Ax - Dx);
                double d = Math.Sqrt(Math.Pow(s, 2) + Math.Pow(s1, 2));
                return a + b + c + d;
            }

        }
        public class vector
        {
            public double Ax { get; set; }
            public double Ay { get; set; }
            public double Bx { get; set; }
            public double By { get; set; }
            public vector (double ax,double ay, double bx, double by)
            {
                Ax = ax;
                Ay = ay;
                Bx = bx;
                By = by;
            }
        }
        static void Main(string[] args)
        {
            shape test = new square(2, 2, 4, 3, 5, 4, 8, 5);
            //Console.WriteLine(test.Perimeter());
            //Console.WriteLine(test.area());
            shape test1 = new Circle(2, 2, 2, 3);
            //Console.WriteLine(test1.Perimeter());
            //Console.WriteLine(test1.area());
            shape test2 = new Triangle(2, 3, 3, 4, 8, 4);
            //Console.WriteLine(test2.Perimeter());
            //Console.WriteLine(test2.area());
            shape[] shapes = { test, test1, test2 };
            for(int i = 0;i < shapes.Length; i++)
            {
                Console.WriteLine(shapes[i].area());
            }
        }
    }
}

