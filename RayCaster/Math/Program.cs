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
            Matrix3 a = new Matrix3(4, 9, 8,
                                    3, 7, 2,
                                    1, 3, 4);
            Matrix3 ba = new Matrix3(4, 9, 8,
                                    3, 7, 2,
                                    1, 3, 4);
            Matrix3 c = a * ba;
            if (c[0,0] != 51 || c[0,1] != 123 || c[0,2] != 82 || c[1,0] != 35 || c[1,1] != 82 || c[1,2] != 46 || c[2,0] != 17 || c[2,1] != 42 || c[2,2] != 30) {
                Error("Multiplication operand broken");
            }
            float det_A = Matrix3.Determinant(a);
            if (det_A != 14) {
                Error("Deterinant is wrong");
                Error("Determinant value: " + det_A + " Expected: 14");
            }
            Matrix3 i = Matrix3.Inverse(a);
            Matrix3 test = new Matrix3(11.0f / 7.0f, -6.0f / 7.0f, -19.0f / 7.0f, 
                                       -5.0f / 7.0f, 4.0f / 7.0f, 8.0f / 7.0f, 
                                       1.0f / 7.0f, -3.0f / 14.0f, 1.0f / 14.0f);
            if (i != test) {
                Error("Inverse Matrix is wrong");
                Console.WriteLine("Actual: ");
                for (int z = 0; z < 3; z++) {
                    for (int j = 0; j < 3; j++) {
                        Console.Write(i[z, j].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Expected: ");
                for (int z = 0; z < 3; z++) {
                    for (int j = 0; j < 3; j++) {
                        Console.Write(test[z, j].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }

            Vector3 v3 = new Vector3(0, 0, 1);
            Matrix3 xRotation = Matrix3.XRotation(90);
            Vector3 newv3 = xRotation * v3;
            if (newv3[0] != 0.0f || newv3[1] != -1.0f || newv3[2] != 0) {
                Error("rotation did not work properly, X: " + newv3[0] + " Y: " + newv3[1] + " Z: " + newv3[2]);
            }
            
            Matrix2 f = new Matrix2(1, 2, 
                                    3, 4);
            if (f.Matrix[0] != 1 && f.Matrix[1] != 2 || f.Matrix[2] != 3 || f.Matrix[3] != 4) {
                Error("Params Constructor Is Broken");
            }
            if (f[0] != 1 && f[1] != 2 || f[2] != 3 || f[3] != 4) {
                Error("Single Dimensional accessor Is Broken");
            }
            if (f[0, 0] != 1 || f[1, 1] != 4 || f[0, 1] != 2 || f[1, 0] != 3) {
                Error("Multidimensional accessor broken");
            }
            if (f.GetValue(0, 0) != 1 || f.GetValue(1, 1) != 4 || f.GetValue(0, 1) != 2 || f.GetValue(1, 0) != 3) {
                Error("Instance GetValue broken");
            }
            if (Matrix2.GetValue(f, 0, 0) != 1 || Matrix2.GetValue(f, 1, 1) != 4 || Matrix2.GetValue(f, 0, 1) != 2 || Matrix2.GetValue(f, 1, 0) != 3) {
                Error("Instance GetValue broken");
            }

            Matrix2 b = new Matrix2(5, 6, 
                                    7, 8);
            Matrix2 h = f + b;
            if (h[0,0] != 6 ||h[0,1] != 8 || h[1,0] != 10 ||h[1,1] != 12) {
                Error("Addition operator is wrong");
            }
            h = f - b;
            if (h[0, 0] != -4 || h[0, 1] != -4 || h[1, 0] != -4 || h[1, 1] != -4) {
                Error("Subtraction operator is wrong");
            }
            h = h * 2;
            if (h[0, 0] != -8 || h[0, 1] != -8 || h[1, 0] != -8 || h[1, 1] != -8) {
                Error("multiply operator is wrong");
            }
            h = f / b;
            if (h[0, 0] != 1.0f/5.0f || h[0, 1] != 2.0f/6.0f || h[1, 0] != 3.0f/7.0f || h[1, 1] != 4.0f/8.0f) {
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
            if ( 0.0f-v[0]>  0.00001f ||1.0f - v[1] > 0.00001f) {
                Error("Vector Multiplication opperand wrong");
                Console.WriteLine("V2[0]: " + v2[0] + " V2[1]: " + v2[1]);
            }


            Console.WriteLine(c[0, 0].ToString() + '\t' + c[0, 1].ToString());
            Console.WriteLine(c[1, 0].ToString() + '\t' + c[1, 1].ToString() + "\n");

            f = new Matrix2(4, 3, 3, 1);
            h = Matrix2.Inverse(f);
            Console.WriteLine(h[0, 0].ToString() + '\t' + h[0, 1].ToString());
            Console.WriteLine(h[1, 0].ToString() + '\t' + h[1, 1].ToString() + "\n");

            Matrix4 a4 = new Matrix4 ( 9,8,9,8,
                                       2,4,3,2,
                                       0,1,3,3,
                                       0,0,0,1);
            Matrix4 ia4 = Matrix4.Inverse(a4);
            if (ia4[0, 0] >= 0.177f || ia4[0, 1] >= -0.295f || ia4[0, 2] >= -0.236f || ia4[0, 3] >= -0.118f ||
                ia4[1, 0] >= -0.118f || ia4[1, 1] >= 0.530f || ia4[1, 2] >= -0.177f || ia4[1, 3] >= 0.412f ||
                ia4[2, 0] >= 0.040f || ia4[2, 1] >= -0.177f || ia4[2, 2] >= 0.393f || ia4[2, 3] >= -1.138f ||
                ia4[3, 0] != 0.0f || ia4[3, 1] != 0.0f || ia4[3, 2] != 0.0f || ia4[3,3] != 1.0f) {
                Error("Inverse Matrix is wrong");
                Console.WriteLine("Actual: ");
                for (int z = 0; z < 4; z++) {
                    for (int j = 0; j < 4; j++) {
                        Console.Write(ia4[z, j].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
            
            Quaternion q = Quaternion.AngleAxis(90.0f, 1.0f, 0.0f, 0.0f);
            Matrix4 m = Matrix4.AngleAxis(90.0f, 1.0f, 0.0f, 0.0f);
            if (q.ToMatrix() != m) {
                Error("Quaternion did not convert to correct matrix");
                Console.WriteLine("Actual: ");
                for (int z = 0; z < 4; z++) {
                    for (int j = 0; j < 4; j++) {
                        Console.Write(q.ToMatrix()[z, j].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Expected: ");
                for (int z = 0; z < 4; z++) {
                    for (int j = 0; j < 4; j++) {
                        Console.Write(m[z, j].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
            Quaternion q1 = Quaternion.FromEuler(90, 0, 0);
            Quaternion q2 = Quaternion.AngleAxis(90, 1, 0, 0);
            if (q1 != q2) {
                Error("From Euler result not correct");
            }
            Quaternion q3 = Quaternion.AngleAxis(90, 0, 1, 0);
            if (Math.Abs(90.0f - q3.ToEuler().Y) < 0.000001f) {
                Error("expecting q3 y to be 90, not : " + q3.ToEuler().Y);
            }

        Vector3 v1 = Matrix4.MultiplyVector(Matrix4.AngleAxis(30f, 0.5f, 0.5f, 0.0f),new Vector3(1.0f, 2.0f, 3.0f));
        Vector3 v5 = Quaternion.AngleAxis(30f, 0.5f, 0.5f, 0.0f) * new Vector3(1.0f, 2.0f, 3.0f);
        if (v1 != v5) {
            Error("v1 != v5");
        }
    Console.ReadLine();
        }
    }
}
