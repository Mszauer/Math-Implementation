using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Implementation {
    class Program {
        static void Error(string error) {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = oldColor;
        }

        static void Main(string[] args) {
            Matrix2 I = new  Matrix2();
            if (I.Matrix[0] != 1 || I.Matrix[1] != 0 || I.Matrix[2] != 0 || I.Matrix[3] != 1) {
                Error("Default Constructor Is Broken");
            }

            Matrix2 a = new Matrix2(1, 2, 
                                    3, 4);
            if (a.Matrix[0] != 1 && a.Matrix[1] != 2 || a.Matrix[2] != 3 || a.Matrix[3] != 4) {
                Error("Params Constructor Is Broken");
            }
            if (a[0] != 1 && a[1] != 2 || a[2] != 3 || a[3] != 4) {
                Error("Single Dimensional accessor Is Broken");
            }
            if (a[0, 0] != 1 || a[1, 1] != 4 || a[0, 1] != 2 || a[1, 0] != 3) {
                Error("Multidimensional accessor broken");
            }
            if (a.GetValue(0, 0) != 1 || a.GetValue(1, 1) != 4 || a.GetValue(0, 1) != 2 || a.GetValue(1, 0) != 3) {
                Error("Instance GetValue broken");
            }
            if (Matrix2.GetValue(a, 0, 0) != 1 || Matrix2.GetValue(a, 1, 1) != 4 || Matrix2.GetValue(a, 0, 1) != 2 || Matrix2.GetValue(a, 1, 0) != 3) {
                Error("Instance GetValue broken");
            }

            Matrix2 b = new Matrix2(5, 6, 
                                    7, 8);
            Matrix2 c = a + b;
            if (c[0,0] != 6 ||c[0,1] != 8 || c[1,0] != 10 ||c[1,1] != 12) {
                Error("Addition operator is wrong");
            }
            c = a - b;
            if (c[0, 0] != -4 || c[0, 1] != -4 || c[1, 0] != -4 || c[1, 1] != -4) {
                Error("Subtraction operator is wrong");
            }
            c = c * 2;
            if (c[0, 0] != -8 || c[0, 1] != -8 || c[1, 0] != -8 || c[1, 1] != -8) {
                Error("multiply operator is wrong");
            }
            c = a / b;
            if (c[0, 0] != 1.0f/5.0f || c[0, 1] != 2.0f/6.0f || c[1, 0] != 3.0f/7.0f || c[1, 1] != 4.0f/8.0f) {
                Error("Division operator is wrong");
            }
            Vector2 v = new Vector2(2, 3);
            Matrix2 d = new Matrix2(4, 5, 6, 7);
            v = d * v;
            if (v[0] != 23.0f || v[1] != 33.0f) {
                Error("Vector Multiplication opperand wrong");
                Console.WriteLine("V[0]: " + v[0] + " V[1]: " + v[1]);
            }

            Vector2 v2 = new Vector2(1, 0);
            Matrix2 rotation = Matrix2.Rotation(90.0f);
            v2 = rotation*v2;
            if (v[0] != 0.0f || v[1] != 1.0f) {
                Error("Vector Multiplication opperand wrong");
                Console.WriteLine("V2[0]: " + v2[0] + " V2[1]: " + v2[1]);
            }


            Console.WriteLine(c[0, 0].ToString() + '\t' + c[0, 1].ToString());
            Console.WriteLine(c[1, 0].ToString() + '\t' + c[1, 1].ToString() + "\n");

            a = new Matrix2(4, 3, 3, 1);
            c = Matrix2.Inverse(a);
            Console.WriteLine(c[0, 0].ToString() + '\t' + c[0, 1].ToString());
            Console.WriteLine(c[1, 0].ToString() + '\t' + c[1, 1].ToString() + "\n");
            Console.ReadLine();
        }
    }
}
