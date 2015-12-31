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
        public float this[int col, int row] {
            get {
                return Matrix[(col * 2) + row];
            }
            set {
                Matrix[(col * 2) + row] = value;
            }
        }
        public Matrix2() {
            Matrix = new float[] { 1, 0,
                                   0, 1 };
        }
        public Matrix2(params float[] values) {
            if (values.Length != 4) {
                Console.WriteLine("Invalid amount of numbers, Values.Length: " + values.Length);
                throw new System.Exception();
            }
            Matrix = new float[4];
            for (int i = 0; i < 4; i++) {
                Matrix[i] = values[i];
            }
        }

        public float GetValue(int row, int col) {
            return Matrix[row * Matrix.Length + col];
        }
        public static float GetValue(Matrix2 matrix, int row, int col) {
            return matrix.Matrix[row * 2 + col];
        }
        public static Matrix2 Add(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row, col] = matrix1[row, col] + matrix2[row, col];
                }
            }
            return result;
        }
        public void Add(Matrix2 matrix) {
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    this[row, col] = matrix[row, col] + this[row, col];
                }
            }
        }
        public static Matrix2 operator +(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row, col] = matrix1[row, col] + matrix2[row, col];
                }
            }
            return result;
        }
        public static Matrix2 Subtract(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row, col] = matrix1[row, col] - matrix2[row, col];
                }
            }
            return result;
        }
        public void Subtract(Matrix2 matrix) {
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    this[row, col] = matrix[row, col] - this[row, col];
                }
            }
        }
        public static Matrix2 operator -(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            for (int row = 0; row < 2; row++) {
                for (int col = 0; col < 2; col++) {
                    result[row, col] = matrix1[row, col] - matrix2[row, col];
                }
            }
            return result;
        }
        public static Matrix2 Multiply(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            result[0, 0] = (matrix1[0, 0] * matrix2[0, 0]) + (matrix1[1, 0] * matrix2[0, 1]);
            result[0, 1] = (matrix1[0, 0] * matrix2[1, 0]) + (matrix1[1, 0] * matrix2[1, 1]);
            result[1, 0] = (matrix1[0, 1] * matrix2[0, 0]) + (matrix1[1, 1] * matrix2[0, 1]);
            result[1, 1] = (matrix1[0, 1] * matrix2[1, 0]) + (matrix1[1, 1] * matrix2[1, 1]);
            return result;
        }
        public void Multiply(Matrix2 matrix) {
            this[0, 0] = (this[0, 0] * matrix[0, 0]) + (this[1, 0] * matrix[0, 1]);
            this[0, 1] = (this[0, 0] * matrix[1, 0]) + (this[1, 0] * matrix[1, 1]);
            this[1, 0] = (this[0, 1] * matrix[0, 0]) + (this[1, 1] * matrix[0, 1]);
            this[1, 1] = (this[0, 1] * matrix[1, 0]) + (this[1, 1] * matrix[1, 1]);
        }
        public static Matrix2 operator *(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            result[0, 0] = (matrix1[0, 0] * matrix2[0, 0]) + (matrix1[1, 0] * matrix2[0, 1]);
            result[0, 1] = (matrix1[0, 0] * matrix2[1, 0]) + (matrix1[1, 0] * matrix2[1, 1]);
            result[1, 0] = (matrix1[0, 1] * matrix2[0, 0]) + (matrix1[1, 1] * matrix2[0, 1]);
            result[1, 1] = (matrix1[0, 1] * matrix2[1, 0]) + (matrix1[1, 1] * matrix2[1, 1]);
            return result;
        }
        public static Matrix2 ScalarMultiply(Matrix2 matrix, float scale) {
            Matrix2 result = matrix;
            for (int i = 0; i < 4; i++) {
                result[i] *= scale;
            }
            return result;
        }
        public void ScalarMultiply(float scale) {
            for (int i = 0; i < 4; i++) {
                this[i] *= scale;
            }
        }
        public static Matrix2 operator *(Matrix2 matrix, float scale) {
            Matrix2 result = matrix;
            for (int i = 0; i < 4; i++) {
                result[i] *= scale;
            }
            return result;
        }
        public static Matrix2 ScalarDivide(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            result[0, 0] = matrix1[0, 0] / matrix2[0, 0];
            result[0, 1] = matrix1[0, 1] / matrix2[0, 1];
            result[1, 0] = matrix1[1, 0] / matrix2[1, 0];
            result[1, 1] = matrix1[1, 1] / matrix2[1, 1];
            return result;
        }
        public void ScalarDivide(Matrix2 matrix) {
            Matrix2 result = new Matrix2();
            this[0, 0] /= matrix[0, 0];
            this[0, 1] /= matrix[0, 1];
            this[1, 0] /= matrix[1, 0];
            this[1, 1] /= matrix[1, 1];
        }
        public static Matrix2 operator /(Matrix2 matrix1, Matrix2 matrix2) {
            Matrix2 result = new Matrix2();
            result[0, 0] = matrix1[0, 0] / matrix2[0, 0];
            result[0, 1] = matrix1[0, 1] / matrix2[0, 1];
            result[1, 0] = matrix1[1, 0] / matrix2[1, 0];
            result[1, 1] = matrix1[1, 1] / matrix2[1, 1];
            return result;
        }
        public static Matrix2 Transpose(Matrix2 matrix) {
            return new Matrix2(matrix[0, 0], matrix[1, 0], matrix[0, 1], matrix[1, 1]);
        }
        public void Transpose() {
            float[] m = Transpose(this).Matrix;
            for (int i = 0; i < 4; i++) {
                Matrix[i] = m[i];
            }
        }
        public static float Determinant(Matrix2 matrix) {
            float result = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
            return result;
        }
        public float Determinant() {
            float result = (this[0, 0] * this[1, 1]) - (this[0, 1] * this[1, 0]);
            return result;
        }
        public static Matrix2 Adjugate(Matrix2 matrix) {
            Matrix2 m = matrix;
            m[0, 0] = matrix[1, 1];
            m[0, 1] = -matrix[0, 1];
            m[1, 0] = -matrix[1, 0];
            m[1, 1] = matrix[0, 0];
            return m;
        }
        public void Adjugate() {
            Matrix2 m = this;
            this[0, 0] = m[1, 1];
            this[0, 1] = -m[0, 1];
            this[1, 0] = -m[1, 0];
            this[1, 1] = m[0, 0];
        }
        public static Matrix2 Inverse(Matrix2 matrix) {
            if (Determinant(matrix) == 0) {
                return matrix;
            }
            return (Adjugate(matrix) * (1 / Determinant(matrix)));
        }
        public void Inverse() {
            if (Determinant() == 0) {
                return;
            }
            Matrix2 m = Adjugate(this) * (1 / Determinant());
            for (int i = 0; i < 4; i++) {
                this[i] = m[i];
            }
        }
        public static Vector2 Multiply(Matrix2 matrix, Vector2 vector) {
            Vector2 result = new Vector2();
            result[0] = (matrix[0, 0] * vector[0]) + (matrix[0, 1] * vector[0]);
            result[1] = (matrix[1, 0] * vector[1]) + (matrix[1, 1] * vector[1]);
            return result;                       
        }
        public Vector2 Multiply(Vector2 vector) {
            Vector2 result = new Vector2();
            result[0] = (this[0, 0] * vector[0]) + (this[0, 1] * vector[0]);
            result[1] = (this[1, 0] * vector[1]) + (this[1, 1] * vector[1]);
            return result;
        }
        public static Vector2 operator *(Matrix2 matrix, Vector2 vector) {
            Vector2 result = new Vector2();
            result[0] = (matrix[0, 0] * vector[0]) + (matrix[0, 1] * vector[0]);
            result[1] = (matrix[1, 0] * vector[1]) + (matrix[1, 1] * vector[1]);
            return result;
        }
        public static Matrix2 Rotation(Matrix2 matrix) {
            Matrix2 result = new Matrix2();

            return result;
        }
    }
}
