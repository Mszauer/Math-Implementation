using System;

namespace Math_Implementation {
    class Matrix4 {
        public float[] Matrix = null;
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
                return Matrix[(i * 4) + j];
            }
            set {
                Matrix[(i * 4) + j] = value;
            }
        }
        public Matrix4() {
            Matrix = new float[] {1,0,0,0,
                                   0,1,0,0,
                                   0,0,1,0,
                                   0,0,0,1};
        }
        public Matrix4(params float[] values) {
            if (values.Length != 16) {
                Console.WriteLine("Invalid amount of matrices added: " + values.Length);
                throw new System.Exception();
            }
            for (int i = 0; i < values.Length; i++) {
                Matrix[i] = values[i];
            }
        }
        //scalar operators
        public static Matrix4 operator +(Matrix4 matrixA,Matrix4 matrixB) {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 4; i++) {
                for(int j = 0; j < 4; j++) {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return result;
        }
        public static Matrix4 operator -(Matrix4 matrixA, Matrix4 matrixB) {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    result[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }
            return result;
        }
        public static Matrix4 operator /(Matrix4 matrixA, Matrix4 matrixB) {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    result[i, j] = matrixA[i, j] / matrixB[i, j];
                }
            }
            return result;
        }
        public static Matrix4 operator *(Matrix4 matrixA, float scale) {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    result[i, j] = matrixA[i, j] * scale;
                }
            }
            return result;
        }
        private static bool Fequal(float a, float b) {
            return Math.Abs(a - b) < 0.00001;
        }
        public static bool operator ==(Matrix4 matrixA, Matrix4 matrixB) {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (!Fequal(matrixA[i, j], matrixB[i, j])) {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(Matrix4 matrixA, Matrix4 matrixB) {
            return !(matrixA == matrixB);
        }
        //vector*matrix
        public static Vector4 operator * (Matrix4 matrixA,Vector4 vectorA) {
            Vector4 result = new Vector4();
            result[0] = (matrixA[0, 0] * vectorA[0]) + (matrixA[0, 1] * vectorA[1]) + (matrixA[0, 2] * vectorA[2]) + (matrixA[0, 3] * vectorA[3]);
            result[1] = (matrixA[1, 0] * vectorA[0]) + (matrixA[1, 1] * vectorA[1]) + (matrixA[1, 2] * vectorA[2]) + (matrixA[1, 3] * vectorA[3]);
            result[2] = (matrixA[2, 0] * vectorA[0]) + (matrixA[2, 1] * vectorA[1]) + (matrixA[2, 2] * vectorA[2]) + (matrixA[2, 3] * vectorA[3]);
            result[3] = (matrixA[3, 0] * vectorA[0]) + (matrixA[3, 1] * vectorA[1]) + (matrixA[3, 2] * vectorA[2]) + (matrixA[3, 3] * vectorA[3]);
            return result;
        }
        //matrix matrix multiplication
        public static Matrix4 operator *(Matrix4 matrixA,Matrix4 matrixB) {
            Matrix4 result = new Matrix4();
            result[0, 0] = matrixA[0, 0] * matrixB[0, 0] + matrixA[0, 1] * matrixB[1, 0] + matrixA[0, 2] * matrixB[2, 0] + matrixA[0, 3] * matrixB[3, 0];
            result[0, 1] = matrixA[0, 0] * matrixB[0, 1] + matrixA[0, 1] * matrixB[1, 1] + matrixA[0, 2] * matrixB[2, 1] + matrixA[0, 3] * matrixB[3, 1];
            result[0, 2] = matrixA[0, 0] * matrixB[0, 2] + matrixA[0, 1] * matrixB[1, 2] + matrixA[0, 2] * matrixB[2, 2] + matrixA[0, 3] * matrixB[3, 2];
            result[0, 3] = matrixA[0, 0] * matrixB[0, 3] + matrixA[0, 1] * matrixB[1, 3] + matrixA[0, 2] * matrixB[2, 3] + matrixA[0, 3] * matrixB[3, 3];
            //
            result[1, 0] = matrixA[1, 0] * matrixB[0, 0] + matrixA[1, 1] * matrixB[1, 0] + matrixA[1, 2] * matrixB[2, 0] + matrixA[0, 3] * matrixB[3, 0];
            result[1, 1] = matrixA[1, 0] * matrixB[0, 1] + matrixA[1, 1] * matrixB[1, 1] + matrixA[1, 2] * matrixB[2, 1] + matrixA[0, 3] * matrixB[3, 1];
            result[1, 2] = matrixA[1, 0] * matrixB[0, 2] + matrixA[1, 1] * matrixB[1, 2] + matrixA[1, 2] * matrixB[2, 2] + matrixA[0, 3] * matrixB[3, 2];
            result[1, 3] = matrixA[1, 0] * matrixB[0, 3] + matrixA[1, 1] * matrixB[1, 3] + matrixA[1, 2] * matrixB[2, 3] + matrixA[0, 3] * matrixB[3, 3];
            //
            result[2, 0] = matrixA[2, 0] * matrixB[0, 0] + matrixA[2, 1] * matrixB[1, 0] + matrixA[2, 2] * matrixB[2, 0] + matrixA[0, 3] * matrixB[3, 0];
            result[2, 1] = matrixA[2, 0] * matrixB[0, 1] + matrixA[2, 1] * matrixB[1, 1] + matrixA[2, 2] * matrixB[2, 1] + matrixA[0, 3] * matrixB[3, 1];
            result[2, 2] = matrixA[2, 0] * matrixB[0, 2] + matrixA[2, 1] * matrixB[1, 2] + matrixA[2, 2] * matrixB[2, 2] + matrixA[0, 3] * matrixB[3, 2];
            result[2, 3] = matrixA[2, 0] * matrixB[0, 3] + matrixA[2, 1] * matrixB[1, 3] + matrixA[2, 3] * matrixB[2, 3] + matrixA[0, 3] * matrixB[3, 3];
            //
            result[3, 0] = matrixA[3, 0] * matrixB[0, 0] + matrixA[3, 1] * matrixB[1, 0] + matrixA[3, 2] * matrixB[2, 0] + matrixA[0, 3] * matrixB[3, 0];
            result[3, 1] = matrixA[3, 0] * matrixB[0, 1] + matrixA[3, 1] * matrixB[1, 1] + matrixA[3, 2] * matrixB[2, 1] + matrixA[0, 3] * matrixB[3, 1];
            result[3, 2] = matrixA[3, 0] * matrixB[0, 2] + matrixA[3, 1] * matrixB[1, 2] + matrixA[3, 2] * matrixB[2, 2] + matrixA[0, 3] * matrixB[3, 2];
            result[3, 3] = matrixA[3, 0] * matrixB[0, 3] + matrixA[3, 1] * matrixB[1, 3] + matrixA[3, 3] * matrixB[2, 3] + matrixA[0, 3] * matrixB[3, 3];
            return result;
        }
        //transpose
        public static Matrix4 Transpose(Matrix4 matrixA) {
            Matrix4 result = new Matrix4();
            for(int i= 0; i < 4; i++) {
                for(int j = 0; j < 4; j++) {
                    result[i, j] = matrixA[j, i];
                }
            }
            return result;
        }
        public static Matrix4 Minor(Matrix4 matrixA) {
            Matrix4 result = new Matrix4();
            result[0, 0] = matrixA[0, 0] * Matrix3.Determinant(new Matrix3(matrixA[1, 1], matrixA[1, 2], matrixA[1, 3], matrixA[2, 1], matrixA[2, 2], matrixA[2, 3], matrixA[3, 1], matrixA[3, 2], matrixA[3, 3]));
            result[0, 1] = matrixA[0, 1] * Matrix3.Determinant(new Matrix3(matrixA[1, 0], matrixA[1, 2], matrixA[1, 3], matrixA[2, 0], matrixA[2, 2], matrixA[2, 3], matrixA[3, 0], matrixA[3, 2], matrixA[3, 3]));
            result[0, 2] = matrixA[0, 2] * Matrix3.Determinant(new Matrix3(matrixA[1, 0], matrixA[1, 1], matrixA[1, 3], matrixA[2, 0], matrixA[2, 1], matrixA[2, 3], matrixA[3, 0], matrixA[3, 1], matrixA[3, 3]));
            result[0, 3] = matrixA[0, 3] * Matrix3.Determinant(new Matrix3(matrixA[1, 0], matrixA[1, 1], matrixA[1, 2], matrixA[2, 0], matrixA[2, 1], matrixA[2, 2], matrixA[3, 0], matrixA[3, 1], matrixA[3, 2]));
            result[1, 0] = matrixA[1, 0] * Matrix3.Determinant(new Matrix3(matrixA[0, 1], matrixA[0, 2], matrixA[0, 3], matrixA[2, 1], matrixA[2, 2], matrixA[2, 3], matrixA[3, 1], matrixA[3, 2], matrixA[3, 3]));
            result[1, 1] = matrixA[1, 1] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 2], matrixA[0, 3], matrixA[2, 0], matrixA[2, 2], matrixA[2, 3], matrixA[3, 0], matrixA[3, 2], matrixA[3, 3]));
            result[1, 2] = matrixA[1, 2] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 1], matrixA[0, 3], matrixA[2, 0], matrixA[2, 1], matrixA[2, 3], matrixA[3, 0], matrixA[3, 1], matrixA[3, 3]));
            result[1, 3] = matrixA[1, 3] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 1], matrixA[0, 2], matrixA[2, 0], matrixA[2, 1], matrixA[2, 2], matrixA[3, 0], matrixA[3, 1], matrixA[3, 2]));
            result[2, 0] = matrixA[2, 0] * Matrix3.Determinant(new Matrix3(matrixA[0, 1], matrixA[0, 2], matrixA[0, 3], matrixA[1, 1], matrixA[1, 2], matrixA[1, 3], matrixA[3, 1], matrixA[3, 2], matrixA[3, 3]));
            result[2, 1] = matrixA[2, 1] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 2], matrixA[0, 3], matrixA[1, 0], matrixA[1, 2], matrixA[1, 3], matrixA[3, 0], matrixA[3, 2], matrixA[3, 3]));
            result[2, 2] = matrixA[2, 2] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 1], matrixA[0, 3], matrixA[1, 0], matrixA[1, 1], matrixA[1, 3], matrixA[3, 0], matrixA[3, 1], matrixA[3, 3]));
            result[2, 3] = matrixA[2, 3] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 1], matrixA[0, 2], matrixA[1, 0], matrixA[1, 1], matrixA[1, 2], matrixA[3, 0], matrixA[3, 1], matrixA[3, 2]));
            result[3, 0] = matrixA[3, 0] * Matrix3.Determinant(new Matrix3(matrixA[0, 1], matrixA[0, 2], matrixA[0, 3], matrixA[1, 1], matrixA[1, 2], matrixA[1, 3], matrixA[2, 1], matrixA[2, 2], matrixA[2, 3]));
            result[3, 1] = matrixA[3, 1] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 2], matrixA[0, 3], matrixA[1, 0], matrixA[1, 2], matrixA[1, 3], matrixA[2, 0], matrixA[2, 2], matrixA[2, 3]));
            result[3, 2] = matrixA[3, 2] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 1], matrixA[0, 3], matrixA[1, 0], matrixA[1, 1], matrixA[1, 3], matrixA[2, 0], matrixA[2, 1], matrixA[2, 3]));
            result[3, 3] = matrixA[3, 3] * Matrix3.Determinant(new Matrix3(matrixA[0, 0], matrixA[0, 1], matrixA[0, 2], matrixA[1, 0], matrixA[1, 1], matrixA[1, 2], matrixA[2, 0], matrixA[2, 1], matrixA[2, 2]));
            return result;
        }
    }
}
