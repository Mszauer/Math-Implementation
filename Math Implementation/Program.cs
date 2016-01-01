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

            Matrix2 b = new Matrix2(5, 6, 7, 8);
            Matrix2 c = a + b;
            if (c[0,0] != 6 ||c[0,1] != 8 || c[1,0] != 10 ||c[1,1] != 12) {
                Error("Addition operator is wrong");
            }
            c = a - b;
            if (c[0, 0] != 4 || c[0, 1] != 4 || c[1, 0] != 4 || c[1, 1] != 4) {
                Error("Subtraction operator is wrong");
            }
            /*
            Console.WriteLine(c[0, 0].ToString() + '\t' + c[0, 1].ToString());
            Console.WriteLine(c[1, 0].ToString() + '\t' + c[1, 1].ToString() + "\n");

            a = new Matrix2(4, 3, 3, 1);
            c = Matrix2.Inverse(a);
            Console.WriteLine(c[0, 0].ToString() + '\t' + c[0, 1].ToString());
            Console.WriteLine(c[1, 0].ToString() + '\t' + c[1, 1].ToString() + "\n");
            */
            Console.ReadLine();
        }
    }
}
