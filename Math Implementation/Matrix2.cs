using System;

namespace Math_Implementation {
    class Matrix2 {
        public float[] Matrix;
        public int Length {
            get {
                return Matrix.Length;
            }
        }
        public float this[int i] {
            get {
                return Matrix[i];
            }
            set {
                Matrix[i] = value;
            }
        }
        public Matrix2() {
            Matrix = new float[2 * 2];
        }
        public Matrix2(int[] values) {
            Matrix = new float[values.Length];
        }

        public float GetValue(int row,int col) {
            return Matrix[row * Matrix.Length + col];
        }
        public static float GetValue(Matrix2 matrix,int row, int col) {
            return matrix.Matrix[row * matrix.Length + col];
        }
        public static Matrix2 Add(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row * result.Length + col] = matrix1[row * matrix1.Length + col] + matrix2[row * matrix2.Length + col];
                }
            }
            return result;
        }
        public void Add(Matrix2 matrix) {
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    Matrix[row * Matrix.Length + col] = matrix[row * matrix.Length + col] + Matrix[row * Matrix.Length + col];
                }
            }
        }
        public static Matrix2 operator +(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row * result.Length + col] = matrix1[row * matrix1.Length + col] + matrix2[row * matrix2.Length + col];
                }
            }
            return result;
        }
        public static Matrix2 Subtract(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row * result.Length + col] = matrix1[row * matrix1.Length + col] - matrix2[row * matrix2.Length + col];
                }
            }
            return result;
        }
        public void Subtract(Matrix2 matrix) {
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    Matrix[row * Matrix.Length + col] = matrix[row * matrix.Length + col] - Matrix[row * Matrix.Length + col];
                }
            }
        }
        public static Matrix2 operator -(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row * result.Length + col] = matrix1[row * matrix1.Length + col] - matrix2[row * matrix2.Length + col];
                }
            }
            return result;
        }
        public static Matrix2 Multiply(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            result[0] =( matrix1[0] * matrix2[0]) + (matrix1[1]*matrix2[2]);
            result[1] = (matrix1[0] * matrix2[1]) + (matrix1[1]*matrix2[3]);
            result[2] = (matrix1[2] * matrix2[2]) + (matrix1[3]*matrix2[1]);
            result[3] = (matrix1[2] * matrix2[1]) + (matrix1[3]*matrix2[3]);
            return result;
        }
    }
}
