using System;

namespace Math_Implementation {
    class Matrix2 {
        public float[] Matrix;
        public float this[int i] {
            get {
                return Matrix[i];
            }
            set {
                Matrix[i] = value;
            }
        }
        public float this[int i,int j] {
            get {
                return Matrix[(i * 2) + j];
            }
            set {
                Matrix[(i * 2) + j] = value;
            }
        }
        public Matrix2() {
            Matrix = new float[] { 1, 0,
                                   0, 1 };
        }
        public Matrix2(params int[] values) {
            Matrix = new float[values.Length];
        }

        public float GetValue(int row,int col) {
            return Matrix[row * Matrix.Length + col];
        }
        public static float GetValue(Matrix2 matrix,int row, int col) {
            return matrix.Matrix[row * 2 + col];
        }
        public static Matrix2 Add(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row,col] = matrix1[row ,col] + matrix2[row ,col];
                }
            }
            return result;
        }
        public void Add(Matrix2 matrix) {
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    this[row,col] = matrix[row,col] + this[row,col];
                }
            }
        }
        public static Matrix2 operator +(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row,col] = matrix1[row,col] + matrix2[row ,col];
                }
            }
            return result;
        }
        public static Matrix2 Subtract(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row,col] = matrix1[row,col] - matrix2[row,col];
                }
            }
            return result;
        }
        public void Subtract(Matrix2 matrix) {
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    this[row,col] = matrix[row,col] - this[row ,col];
                }
            }
        }
        public static Matrix2 operator -(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row,col] = matrix1[row,col] - matrix2[row,col];
                }
            }
            return result;
        }
        public static Matrix2 Multiply(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            result[0] =( matrix1[0,0] * matrix2[0,0]) + (matrix1[0,1]*matrix2[1,0]);
            return result;
        }
    }
}
